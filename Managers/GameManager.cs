using System;
using System.Threading;
using TextBasedGame.GameCycle;
using TextBasedGame.JSON.dialogues;

namespace TextBasedGame.Manager
{
    public class GameManager
    {
        int choose;
        public Random random = new Random();
        Player player = new Player();
        Enemy enemy = new Enemy();
        FightManager fightManager = new FightManager();
        Dialogue dialogue = new Dialogue();
        public void StartGame()
        {
            if (player.Health == 0) player.Health = 100;
            PlayerInit();
            while (player.Health != 0)
            {
                GetRandomEnemy();
                fightManager.FightCycle(player, enemy);
                if (fightManager.Room != 1) 
                { 
                    enemy.AttackDamage++;
                    enemy.AbilityPower++;
                    enemy.Defense++;
                }
                if (0 == fightManager.Room % 5) dialogue.BlacksmithRoom(player);
            }
        }

        public void PlayerInit()
        {
            Console.Clear();
            Console.WriteLine("Enter a name: ");
            player.Name = Console.ReadLine();
            Console.WriteLine();
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
            int randomNumber = random.Next(1, 4); 

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