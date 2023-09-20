using System;
using System.Threading;

namespace AntMaze.GameCycle
{
    public class Enemy : Character
    {
        public string Role;
        private Random _random = new Random();

        public int GetInput()
        {
            return _random.Next(1, 4);
        }

        public override void GetHit(int damage)
        {
            base.GetHit(damage);
            Console.WriteLine(Role + " take " + damage + " damage:");
            Thread.Sleep(2000);
        }

        public void GetRandomEnemy(Enemy enemy)
        {
            int randomNumber = _random.Next(1, 4);

            switch (randomNumber)
            {
                case 1:
                    enemy = new FireAnt();
                    break;
                case 2:
                    enemy = new TankAnt();
                    break;
                case 3:
                    enemy = new Ant();
                    break;
                default:
                    enemy = null;
                    break;
            }
        }
    }

    public class FireAnt : Enemy
    {
        public FireAnt()
        {
            Health = 40;
            AttackDamage = 9;
            Defense = 1;
            AbilityPower = 9;
            Role = "FireAnt";
        }
    }

    public class TankAnt : Enemy
    {
        public TankAnt()
        {
            Health = 60;
            AttackDamage = 9;
            Defense = 6;
            AbilityPower = 9;
            Role = "TankAnt";
        }
    }

    public class Ant : Enemy
    {
        public Ant()
        {
            Health = 50;
            AttackDamage = 12;
            Defense = 3;
            AbilityPower = 12;
            Role = "Ant";
        }
    }
}