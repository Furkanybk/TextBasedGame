using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextBasedGame.GameManager.GameCycle;

namespace TextBasedGame.GameManager.FightCycle
{
    internal class FightManager
    {
        Player player = new LongSword();
        Enemy enemy = new FireAnt();
        int room = 1;
        public void FightCycl(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"Room {room}");

            while (player.Health > 0 && enemy.Health > 0)
            {
                // Oyuncu saldırır
                int playerDamage = player.Hit(enemy.Defense);
                enemy.GetHit(playerDamage);
                Console.WriteLine($"{playerDamage} you damaged.  ant health: {enemy.Health}");
                Thread.Sleep(500);
                // Düşman saldırır
                int enemyDamage = enemy.Hit(player.Defense);
                player.GetHit(enemyDamage);
                Console.WriteLine($"{enemy.Role} {enemyDamage} damage to you. Your Health: {player.Health}");
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
