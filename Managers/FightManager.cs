using System;
using System.Threading;
using TextBasedGame.GameCycle;

namespace TextBasedGame.Manager
{
    internal class FightManager
    {
        int room = 1;

        public void FightCycle(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"Room {room}");

            while (player.Health > 0 && enemy.Health > 0)
            {
                // Oyuncu saldırır
                player.Hit(enemy);
                Thread.Sleep(500);

                // Düşman saldırır
                enemy.Hit(player);
                Thread.Sleep(500);

                Console.WriteLine();
            }

            if (player.Health > 0)
            {
                Console.WriteLine($"{player.Name} kazandı!");
                room++;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{enemy.Role} kazandı!");
                Console.ReadKey();
            }
        }

    }
}
