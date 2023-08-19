using System;

namespace TextBasedGame.Enemies
{
    public class BaseEnemy : IEnemy
    {
        #region Variable Field

        private int _health;
        private int _defence;
        private int _attack;

        #endregion

        #region Property Field

        public int Health { get => _health; set { _health = value; } }
        public int Defence { get => _defence; set { _defence = value; } }
        public int Attack { get => _attack; set { _attack = value; } }
        public int Chance { get; set; }

        #endregion


        #region Method Field

        public virtual void SetEnemyStats()
        {
            _health = 100;
            _defence = 3;
            _attack = 8;
        }

        public virtual void DealDamagePlayer(Player player)
        {
            int pureDamage = _attack - player.Defence;
            player.GetHit(pureDamage);
        }

        public virtual void GetHit(int damage)
        {
            if (_health < damage)
            {
                _health = 0;
                return;
            }

            _health -= damage;
        }

        public virtual void Dead()
        {
            Console.WriteLine("Enemy dead.");
        }

        void IEnemy.Attack()
        {

        }

        #endregion
    }
}