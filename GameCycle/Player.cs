using System;

namespace TextBasedGame.GameCycle
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; private set; }
        public int AttackDamage { get; set; }
        public int Defense
        {
            get
            {
                return _defense + PlayerWeapon.Defense;
            }

            set => _defense = value;
        }

        public Weapon PlayerWeapon;

        private int _defense;

        public Player()
        {
            Health = 100;
            AttackDamage = 3;
            Defense = 2;
        }

        public void Hit(Enemy enemy)
        {
            int attack = AttackDamage + PlayerWeapon.Attack;
            attack -= enemy.Defense;
            attack = attack < 0 ? 0 : attack;
            enemy.GetHit(attack);
            Console.WriteLine($"{attack} you damaged.  ant health: {enemy.Health}");
        }

        public void GetHit(int damage)
        {
            Health -= damage;
            Health = Health < 0 ? 0 : Health;
        }
    }

    public abstract class Weapon
    {
        public int Attack;
        public int Defense;
    }

    public class LongSword : Weapon
    {
        public LongSword()
        {
            Attack = 10;
            Defense = 10;
        }
    }

    public class Dagger : Weapon
    {
       public Dagger()
        {
            Attack = 10;
            Defense = 10;
        }
    }

    public class Staff : Weapon
    {
        public Staff()
        {
            Attack = 10;
            Defense = 10;
        }
    }
}