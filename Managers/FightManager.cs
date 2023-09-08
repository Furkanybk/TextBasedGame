using System;
using System.Diagnostics;
using System.Threading;
using TextBasedGame.GameCycle;

namespace TextBasedGame.Manager
{
    internal class FightManager
    {
        Random random = new Random();
        private int _playerChoose;
        private int _room = 1;
        private int _enemyDamage;
        private int _playerDamage;
        private int _enemyChoose;

        public void FightCycle(Player player, Enemy enemy)
        {
            Console.Clear();
            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.Clear();
                Console.WriteLine($"Room {_room}");
                Console.WriteLine($"Your Health: {player.Health} /  {enemy.Role} Health: {enemy.Health}");
                Console.WriteLine("1-Attack");
                Console.WriteLine("2-CounterAttack");
                Console.WriteLine("3-Magic Damage");
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
                _enemyChoose = enemy.GetInput();
                if (_playerChoose == _enemyChoose)
                {
                    Console.WriteLine("Berabere!");
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
                            Thread.Sleep(400);
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
                _room++;
                Thread.Sleep(600);
            }
            else
            {
                Console.WriteLine($"{enemy.Role} kazandı!");
                Console.ReadKey();
            }
        }
    }
}