using System;

namespace TextBasedGame.GameCycle
{
    public class Enemy
    {
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        public int Defense { get; set; }
        public string Role { get; set; }

        public void Hit(Player player)
        {
            int attack = AttackDamage;
            attack -= player.Defense;
            attack = attack < 0 ? 0 : attack;
            player.GetHit(attack);
            Console.WriteLine($"{attack} ant damaged.  you health: {player.Health}");
        }

        public void GetHit(int damage)
        {
            Health -= damage; 
            Health = Health < 0 ? 0 : Health;
        }
    }

    public class FireAnt : Enemy
    {
        public FireAnt()
        {
            Health = 40;
            AttackDamage = 6;
            Defense = 1;
            Role = "FireAnt";
        }
    }

    public class TankAnt : Enemy
    {
        public TankAnt()
        {
            Health = 50;
            AttackDamage = 3;
            Defense = 5;
            Role = "TankAnt";
        }
    }

    public class Ant : Enemy
    {
        public Ant()
        {
            Health = 50;
            AttackDamage = 5;
            Defense = 3;
            Role = "Ant";
        }
    }
}