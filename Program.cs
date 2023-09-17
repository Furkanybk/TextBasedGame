using System;
using System.Threading;
using AntMaze.Manager;

namespace AntMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ant-Maze";
            GameManager gameManager = new GameManager();

            int choose = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome the Ant-Maze");
                Console.WriteLine("1-Start New Game");
                Console.WriteLine("2-Load Game");
                Console.WriteLine("3-Exit");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please choose a valid option: ");
                    Thread.Sleep(500);
                }

                switch (choose)
                {
                    case 1:
                        gameManager.StartNewGame();
                        break;
                    case 2:
                        gameManager.StartLoadedGame();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}