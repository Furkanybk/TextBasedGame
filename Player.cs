using System;

namespace TextBasedGame
{
    public enum RoleType
    {
        Brawler,
        Wizard,
        Thief
    }

    public class Player
    {
        public string _name;
        public RoleType _roleType;

        public int Health;
        public int Damage;
        public int Defence;

        public Player()
        {
            Health = 100;
            Damage = 20;
            Defence = 10;
        }

        public void Initialize(string name, int roleType)
        {
            _name = name;
            _roleType = (RoleType)roleType;
        }
        public int GetHit(int damage)
        {
            if (damage > Health) 
            {
                Health = 0;
                return 0;
            }
            damage -= Defence;
            Health -= damage;
            return Health;
        }
      
    }
}
