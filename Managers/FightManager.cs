using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using AntMaze.GameCycle;
using AntMaze.JSON.Save;

namespace AntMaze.Manager
{
    internal class FightManager
    {
        SaveMethods save = new SaveMethods();   
        private int _playerChoose;
        public int Room = 1;
        private int _enemyChoose;

        public void LookStats(Player player)
        {
            Console.Clear();
            Console.WriteLine("Health" + player.Health);
            Console.WriteLine("AttackDamage: " + player.AttackDamage);
            Console.WriteLine("AbilityPower: " + player.AbilityPower);
            Console.WriteLine("Defense: " + player.Defense);
            Console.WriteLine("Agility: " + player.Agility);
            Console.WriteLine("Press enter to return the fight:");
            save.SaveGame(player);
            Console.ReadKey();
        }

        public void FightCycle(Player player, Enemy enemy)
        {
            Console.Clear();
            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.Clear();
                player.CurrentRoom = Room;
                Console.WriteLine($"Room {Room}");
                Console.WriteLine($"Your Health: {player.Health} /  {enemy.Role} Health: {enemy.Health}");
                Console.WriteLine("1-Attack");
                Console.WriteLine("2-CounterAttack");
                Console.WriteLine("3-MagicAttack");
                Console.WriteLine("4-LookStats");
                try
                {
                    _playerChoose = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please choose a valid option.");
                    Thread.Sleep(400);
                    continue;
                }
                if (_playerChoose == 4)
                {
                    LookStats(player);
                    continue;
                }
                if (_playerChoose == 2 || _playerChoose == 1 || _playerChoose == 3 || _playerChoose == 4) continue;
                _enemyChoose = enemy.GetInput();
                switch (_enemyChoose)
                {
                    case 1:
                        Console.WriteLine(enemy.Role + " used Attack");
                        break;
                    case 2:
                        Console.WriteLine(enemy.Role + " used CounterAttack");
                        break;
                    case 3:
                        Console.WriteLine(enemy.Role + " used MagicAttack");
                        break;
                }

                if (_playerChoose == _enemyChoose)
                {
                    Console.WriteLine("Draw!");
                    Thread.Sleep(1000);
                }
                else if ((_playerChoose == 1 && _enemyChoose == 3) ||
                         (_playerChoose == 2 && _enemyChoose == 1) ||
                         (_playerChoose == 3 && _enemyChoose == 2))
                {
                    switch (_playerChoose)
                    {
                        case 1:
                            player.Attack(enemy);
                            break;
                        case 2:
                            player.CounterAttack(enemy);
                            break;
                        case 3:
                            player.MagicAttack(enemy);
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option.");
                            Thread.Sleep(600);
                            continue;
                    }
                }
                else
                {
                    switch (_enemyChoose)
                    {
                        case 1:
                            enemy.Attack(player);
                            break;
                        case 2:
                            enemy.CounterAttack(player);
                            break;
                        case 3:
                            enemy.MagicAttack(player);
                            break;
                    }
                }
            }

            if (player.Health > 0)
            {
                Console.WriteLine($"{player.Name} kazandı!");
                Room++;
                player.CurrentRoom++;
                save.SaveGame(player);
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"{enemy.Role} kazandı!");
                Room++;
                player.CurrentRoom = 0;
                save.SaveGame(player);
                Console.ReadKey();
            }
        }
    }
}