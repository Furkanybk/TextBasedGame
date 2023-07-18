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
        public int Attack;
        public int Defence;

        public Player()
        {
            Health = 100;
            Attack = 10;
            Defence = 10;
        }

        public void Initialize(string name, int roleType)
        {
            _name = name;
            _roleType = (RoleType)roleType;
        }
        
        public void GetHit(int damage) 
        {
            Health -= damage;
            Console.WriteLine("Player get hit " + damage + " damage.");
        }
    }
}
