using System;
using System.Threading;

namespace TextBasedGame.GameCycle
{
    public class Player : Character
    {
        public override void GetHit(int damage)
        {
            base.GetHit(damage);
            Console.WriteLine($"You took {damage} damage"); 
            Thread.Sleep(2000);
        }
    }
}