using System;

namespace TextBasedGame.Managers
{
    public class FightCycle
    {
        private Player _player;
        private BaseEnemy _enemy;

        public void StartCycle(Player player, BaseEnemy enemy)
        {
            _player = player;
            _enemy = enemy;
            UpdateCycle();
        }

        private void UpdateCycle()
        {
            while (true)
            {
                if (_player.Health == 0 || _enemy.Health == 0) break;

                _player.DealDamageEnemy(_enemy);
                _enemy.DealDamagePlayer(_player);

                Console.WriteLine("Player Health:" + _player.Health);
                Console.WriteLine("Enemy Health:" + _enemy.Health);

                Console.ReadKey();
            }

            EndCycle();
        }

        private void EndCycle()
        {
            Console.WriteLine("Fight End");
        }
    }
}

