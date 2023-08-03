using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame.Managers
{
    public class GameCycle
    {
        private FightCycle _fightCycle;
        private Player _player;
        private List<BaseEnemy> _enemies;

        private int _progress;

        public void Initialize(Player player)
        {
            _player = player;
            _fightCycle = new FightCycle();
            _enemies = new List<BaseEnemy>();
            StartCycle();
        }

        public void StartCycle()
        {
            _progress = 1;

            for (int i = 0; i < _progress; i++)
            {
                BaseEnemy enemy = new BanditEnemy();
                enemy.SetEnemyStats();
                _enemies.Add(enemy);
            }

            UpdateCycle();
        }

        private void UpdateCycle()
        {
            while (true)
            {
                _fightCycle.StartCycle(_player, _enemies[0]);
                break;
            }

            EndCycle();
        }

        private void EndCycle()
        {
            Console.WriteLine("End Game");
            Console.ReadKey();
        }

        private void UpgradeProgress()
        {

        }
    }
}
