using System;
using TextBasedGame.Managers;

namespace TextBasedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.MainMenu();
            Console.ReadKey();
            
        }
    }
}