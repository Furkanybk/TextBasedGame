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
        #region Variable Field

        private string _name;
        private RoleType _type;

        private int _health;
        private int _defence;
        private int _attack;

        #endregion

        #region Property Field

        public int Health => _health;
        public int Defence => _defence;
        public int Attack => _attack;

        #endregion


        #region Method Field

        public void Initialize(string name, int type)
        {
            _name = name;
            _type = (RoleType)type;
            SetPlayerStats(100, 20, 10);
        }

        public void SetPlayerStats(int health, int defence, int attack)
        {
            _health = health;
            _defence = defence;
            _attack = attack;
        }

        public void DealDamageEnemy(BaseEnemy enemy)
        {
            int pureDamage = _attack - enemy.Defence;
            enemy.GetHit(pureDamage);
        }

        public void GetHit(int damage)
        {
            if (_health < damage)
            {
                _health = 0;
                return;
            }

            _health -= damage;
        }

        #endregion
    }
}