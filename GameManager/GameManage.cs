using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextBasedGame.GameManager.FightCycle;
using TextBasedGame.GameManager.GameCycle;

namespace TextBasedGame.GameManager
{
    internal class GameManage
    {
        int choose;
        public Random random = new Random();
        Player player = new Player();
        Enemy enemy = new Enemy();
        FightManager fightManager = new FightManager();
        public void StartGame()
        {
            Playerİnit();
            while (player.Health != 0)
            {
                GetRandomEnemy();
                fightManager.FightCycl(player, enemy);
            }
        }

        public void Playerİnit()
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



        public Enemy GetRandomEnemy()
        {
            // Rastgele bir düşman seçmek için Enemy alt sınıflarından birini seçebilirsiniz.
            int randomNumber = random.Next(1, 4); // 1 ila 3 arasında rastgele bir sayı alır.

            switch (randomNumber)
            {
                case 1:
                    return enemy = new FireAnt();
                case 2:
                    return enemy = new TankAnt();
                case 3:
                    return enemy = new Ant();
                default:
                    return null;
            }
        }
    }
}

