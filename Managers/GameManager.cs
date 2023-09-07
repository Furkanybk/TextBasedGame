using System;
using System.Threading;
using TextBasedGame.GameCycle;

namespace TextBasedGame.Manager
{
    public class GameManager
    {
        int choose;
        public Random random = new Random();
        Player player = new Player();
        Enemy enemy = new Enemy();
        FightManager fightManager = new FightManager();
        public void StartGame()
        {
            PlayerInit();
            while (player.Health != 0)
            {
                GetRandomEnemy();
                fightManager.FightCycle(player, enemy);
            }
        }

        public void PlayerInit()
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
                            player.PlayerWeapon = new LongSword();
                            break;
                        case 2:
                            player.PlayerWeapon = new Dagger();
                            break;
                        case 3:
                            player.PlayerWeapon = new Staff();
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