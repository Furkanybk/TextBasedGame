using System;
using System.Numerics;

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
    }

    public class FireAnt : Enemy
    {
        public FireAnt()
        {
            Health = 40;
            AttackDamage = 10;
            Defense = 1;
            Role = "FireAnt";
        }
    }

    public class TankAnt : Enemy
    {
        public TankAnt()
        {
            Health = 60;
            AttackDamage = 6;
            Defense = 5;
            Role = "TankAnt";
        }
    }

    public class Ant : Enemy
    {
        public Ant()
        {
            Health = 50;
            AttackDamage = 7;
            Defense = 3;
            Role = "Ant";
        }
    }
}