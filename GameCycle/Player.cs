using System;

namespace TextBasedGame.GameCycle
{
    public class Player : Character
    {
        public override void GetHit(int damage)
        {
            base.GetHit(damage);
            Console.WriteLine($"player take {damage} damage:");
        }
    }
}