using System;
using System.Threading;

namespace TextBasedGame.GameCycle
{
    public class Enemy : Character 
    {
        public string Role { get; set; }
        Random random = new Random();
        public int GetInput()
        {
            return random.Next(1, 4);
        }

        public override void GetHit(int damage)
        {
            base.GetHit(damage);
            Console.WriteLine(Role + " take " + damage + " damage:");
            Thread.Sleep(2000);
        }
    }

    public class FireAnt : Enemy
    {
        public FireAnt()
        {
            Health = 40;
            AttackDamage = 6;
            Defense = 1;
            AbilityPower = 10;
            Role = "FireAnt";
        }
    }

    public class TankAnt : Enemy
    {
        public TankAnt()
        {
            Health = 60;
            AttackDamage = 6;
            Defense = 6;
            AbilityPower = 6;
            Role = "TankAnt";
        }
    }

    public class Ant : Enemy
    {
        public Ant()
        {
            Health = 50;
            AttackDamage = 10;
            Defense = 3;
            AbilityPower = 9;
            Role = "Ant";
        }
    }
}