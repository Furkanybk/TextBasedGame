using System;

namespace TextBasedGame
{
    public class BanditEnemy : BaseEnemy
    {
        public override void GetHit(int damage)
        {
            base.GetHit(damage);
            System.Console.WriteLine("BanditEnemy");
        }

        public override void Dead()
        {
            Console.WriteLine("Bandit dead.");
        }
    }
}