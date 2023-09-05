using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame.GameManager.GameCycle
{
    public class Enemy
    {
        public virtual int Health { get; set; }
        public virtual int AttackDamage { get; set; }
        public virtual int Defense { get; set; }
        public virtual string Role { get; set; }

        public int Hit(int defense)
        {
            AttackDamage = defense;
            return AttackDamage;
        }

        public int GetHit(int damage)
        {
            Health -= damage;
            return Health;
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