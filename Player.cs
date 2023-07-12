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
        private string _name;
        public RoleType _roleType;

        private int _health;
        private int _attack;
        private int _defence;
        
        private int _strength;
        private int _agility;
        private int _intelligent;

        public void Initialize(string name, int roleType)
        {
            _name = name;
            _roleType = (RoleType)roleType;

            switch (_roleType)
            {
                case RoleType.Brawler:
                    _strength = 10;
                    _health = 100;
                    _defence = 5;
                    _intelligent = 5;
                    _agility = 5;
                    break;
                case RoleType.Wizard:
                    _strength = 5;
                    _health = 100;
                    _defence = 5;
                    _intelligent = 10;
                    _agility = 5;
                    break;
                case RoleType.Thief:
                    _strength = 5;
                    _health = 100;
                    _defence = 5;
                    _intelligent = 5;
                    _agility = 10;
                    break;
            }
        }
    }
}
