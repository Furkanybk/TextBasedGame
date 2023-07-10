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
                    break;
                case RoleType.Wizard:
                    break;
                case RoleType.Thief:
                    break;
            }
        }
    }
}
