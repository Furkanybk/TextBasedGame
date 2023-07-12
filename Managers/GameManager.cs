using System;

namespace TextBasedGame.Managers
{
    public class GameManager
    {
        private Player _player;
        private Enemy _enemy;

        //Constructor method, bu method new denilerek bir değişken oluştuğunda çalışır.
        public GameManager()
        {
            Console.WriteLine("Burası constructer method!");
            _player = new Player();
        }

        public void Initialize()
        {
            StartGame();
        }

        private void StartGame()
        {
            Console.Write("Name:");
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
    }
}