using System;
using System.Threading;
using AntMaze.GameCycle;
using AntMaze.JSON.dialogues;
using AntMaze.JSON.Save;

namespace AntMaze.Manager
{
    public class GameManager
    {
        int choose;
        private int _choose;
        public Random random = new Random();
        Player player = new Player();
        Enemy enemy = new Enemy();
        FightManager fightManager = new FightManager();
        DialogueMethods dialogue = new DialogueMethods();
        SaveMethods save = new SaveMethods();
        public void StartNewGame()
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
                save.SaveGame(player);
                if (0 == fightManager.Room % 5) BlacksmithRoom(player);
            }
        }

        public void StartLoadedGame()
        {
            Console.Clear();
            player.PlayerWeapon = new LongSword();
            player.PlayerReset(player);
            player = save.LoadGame(player);
            while (player.Health != 0 && player !=null)
            {
                if (player.AttackDamage == 0) break;
                GetRandomEnemy();
                fightManager.FightCycle(player, enemy);
                if (fightManager.Room != 1)
                {
                    enemy.AttackDamage++;
                    enemy.AbilityPower++;
                    enemy.Defense++;
                }
                save.LoadSaveGame(player);
                if (0 == player.CurrentRoom % 5 && player.Health != 5) BlacksmithRoom(player);
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

        public void BlacksmithRoom(Player player)
        {
            Console.Clear();
            Console.WriteLine("Welcome to grasshopper blacksmith:");
            Console.WriteLine(dialogue.WriteRandomDialogue());
            Console.WriteLine("Choose something");
            Console.WriteLine("1-Health orb");
            Console.WriteLine("2-Magical necklace");
            Console.WriteLine("3-Warrior ring");
            Console.WriteLine("4-Athletic boots");
            Console.WriteLine("5-Piece of armor");
             _choose = int.Parse(Console.ReadLine());
            switch (_choose)
            {
                case 1:
                    player.Health += 5;
                    break;
                case 2:
                    player.AbilityPower += 3;
                    break;
                case 3:
                    player.AttackDamage += 3;
                    break;
                case 4:
                    player.Agility += 5;
                    break;
                case 5:
                    player.Defense += 2;
                    break;
            }
            Thread.Sleep(1000);
        }
    }
}