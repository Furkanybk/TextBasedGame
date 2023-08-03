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
        FightCycle fightCycle = new FightCycle();
        Enemy enemy = new Enemy();
        private List<Enemy> _enemies = new List<Enemy>();


        int round = 1;
        int enemyCount = 1;
        int skillPoints = 1;

        public void GameUpdate(Player player)
        {
            if (enemy.Health <= 0)
            {

                UpdateRoundAndSkillPoints();
                Console.WriteLine("Round: " + round + "\n You have " + skillPoints + "skill points");
                SkillUpgradeMenu(player);
                CreateEnemy(enemyCount);
                fightCycle.StartFight(player, enemy);
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine("you died" + "your best reach round: " + round + "\n press any key for continue");
                Console.ReadKey();
                fightCycle.EndFight();
            }
        }

        public void UpdateRoundAndSkillPoints()
        {
            round++;
            enemyCount++;
            skillPoints++;
        }

        public void SkillUpgradeMenu(Player player)
        {
            Console.Clear();
            Console.WriteLine("Choose the skill to upgrade:");
            Console.WriteLine("1) Defence");
            Console.WriteLine("2) AttackDamage");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    player.Defence++;
                    skillPoints--;
                    break;
                case "2":
                    player.Damage++;
                    skillPoints--;
                    break;
                default:
                    Console.Write("Please choose valid option");
                    break;
            }
        }

        public void CreateEnemy(int enemyCount)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                _enemies.Add(new Enemy()); 
            }
        }
    }
}
