using System;

namespace TextBasedGame
{
    public class WitchEnemy : BaseEnemy
    {
        public override void SetEnemyStats()
        {
            Health = 50;
            Attack = 200;
            Defence = 20;
        }

        public override void Dead()
        {
            Console.WriteLine("Witch dead.");
            //player gets 10 hp
        }
    }
}