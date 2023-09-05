using System;
using System.Threading;
using TextBasedGame.Manager;

namespace TextBasedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            int x = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome the Ant-Maze");
                Console.WriteLine("1-Start Game");
                Console.WriteLine("2-Load Game");
                Console.WriteLine("3-Exit");
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please choose a valid option: ");
                    Thread.Sleep(500);
                }

                switch (x)
                {
                    case 1:
                        gameManager.StartGame();
                        break;
                    case 2:

                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}