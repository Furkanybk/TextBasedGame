using System;

namespace TextBasedGame.Managers
{
    public class GameManager
    {
        private Player _player;

        public void Initialize()
        {
            //MainMenu Cycle
            while (true)
            {
                PrintMainMenu();
            }
        }

        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("TextBasedGame:");
            Console.WriteLine("1) Start Game");
            Console.WriteLine("2) Leaderboard");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    PlayerInitCycle();
                    StartGame();
                    break;
                case "2":
                    LeaderBoard();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Write("Please choose valid option");
                    break;
            }
        }

        private void PlayerInitCycle()
        {
            _player = new Player();
            Console.Write("Please choose your name:");
            string name = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Choose your role (Brawler: 0 | Wizard: 1 | Thief: 2)");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int roleType) && (roleType == 0 || roleType == 1 || roleType == 2))
                {
                    _player.Initialize(name, roleType);
                    Console.WriteLine(name + "-" + roleType + " success!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter valid roleType!\n");
                }
            }
        }

        private void StartGame()
        {
            Console.Write("StartGame");
            Console.ReadKey();
        }

        private void LeaderBoard()
        {
            Console.Write("LeaderBoard");
            Console.ReadKey();
        }
    }
}