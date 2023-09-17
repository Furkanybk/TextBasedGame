using System;
using System.Threading;

namespace AntMaze.GameCycle
{
    public class Player : Character
    {
        public int Id;
        public int CurrentRoom;
        private int _choose;
        public override void GetHit(int damage)
        {
            base.GetHit(damage);
            Console.WriteLine($"You took {damage} damage");
            Thread.Sleep(2000);
        }

        public Player PlayerReset(Player player)
        {
            player.WeaponDefense = 0;
            player.WeaponAgilityPower = 0;
            player.WeaponDefense = 0;
            player.WeaponAttackDamage = 0;
            player.PlayerWeapon.AttackDamage = 0;
            player.PlayerWeapon.Agility = 0;
            player.PlayerWeapon.Defense = 0;
            player.PlayerWeapon.AbilityPower = 0;
            return player;
        }

        public void PlayerInit(Player _player)
        {
            Console.Clear();
            Console.WriteLine("Enter a name: ");
            _player.Name = Console.ReadLine();
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Choose a weapon: ");
                Console.WriteLine("1-LongSword");
                Console.WriteLine("2-Dagger");
                Console.WriteLine("3-Staff");
                try
                {
                    _choose = int.Parse(Console.ReadLine());
                    switch (_choose)
                    {
                        case 1:
                            _player.PlayerWeapon = new LongSword();
                            break;
                        case 2:
                            _player.PlayerWeapon = new Dagger();
                            break;
                        case 3:
                            _player.PlayerWeapon = new Staff();
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option: ");
                            break;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Please choose a valid option: ");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
        }
    }
}