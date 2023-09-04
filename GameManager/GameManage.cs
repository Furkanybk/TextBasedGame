using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextBasedGame.GameManager.GameCycle;

namespace TextBasedGame.GameManager
{
    internal class GameManage
    {
        int choose;
        Player player = new Player();
        public void StartGame()
        {
            Gameİnit();
        }

        public void Gameİnit()
        {
            Console.WriteLine("Enter a name: ");
            player.Name = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Choose a weapon: ");
                Console.WriteLine("1-LongSword");
                Console.WriteLine("2-Dagger");
                Console.WriteLine("3-Staff");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            player = new LongSword();
                            break;
                        case 2:
                            player = new Dagger();
                            break;
                        case 3:
                            player = new Staff();
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option: ");
                            break;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Please choose a valid option: ");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
        }
    }
}

