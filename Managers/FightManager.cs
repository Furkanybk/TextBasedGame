using System;
using System.Threading;
using TextBasedGame.GameCycle;

namespace TextBasedGame.Manager
{
    internal class FightManager
    {
        int x;
        int room = 1;

        public void FightCycle(Player player, Enemy enemy)
        {
            Console.Clear();
            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.Clear();
                Console.WriteLine($"Room {room}");
                Console.WriteLine($"Your Health: {player.Health} /  Ant Health: {enemy.Health}");
                Console.WriteLine("1-Attack");
                //More options
                try
                {
                    x = Convert.ToInt32(Console.ReadLine()); 
                }
                catch 
                {
                    Console.WriteLine("Please choose a valid option.");
                    Thread.Sleep(400);
                }
                switch (x)
                {
                    case 1:
                        player.Hit(enemy);
                        break;
                }
                enemy.Hit(player);
                Console.WriteLine($"Ant hit you, your health {player.Health}");
                Thread.Sleep(400);
            }

            if (player.Health > 0)
            {
                Console.WriteLine($"{player.Name} kazandı!");
                room++;
                Thread.Sleep(600);
            }
            else
            {
                Console.WriteLine($"{enemy.Role} kazandı!");
                Console.ReadKey();
            }
        }

    }
}
