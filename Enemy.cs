using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame
{
    public class Enemy
    {
        Random random = new Random();
        int EnemyHealth, EnemyAttack, EnemyDefence;
        public void TankEnemy()
        {
            EnemyHealth = random.Next(100, 200);
            EnemyDefence = random.Next(10, 30);
            EnemyAttack = 1;
        }
        public void PowerlessEnemy()
        {
            EnemyHealth = random.Next(10, 30);
            EnemyDefence = random.Next(1, 5);
            EnemyAttack = random.Next(1, 10);
        }
        public void PowerfulEnemy()
        {
            EnemyHealth = random.Next(50, 80);
            EnemyDefence = random.Next(5, 10);
            EnemyAttack = random.Next(5, 10);
        }
    }
}
