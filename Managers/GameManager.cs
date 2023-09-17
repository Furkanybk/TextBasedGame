using System;
using System.Threading;
using AntMaze.GameCycle;
using AntMaze.JSON.dialogues;
using AntMaze.JSON.Save;

namespace AntMaze.Manager
{
    public class GameManager
    {
        private int _choose;
        private Random _random = new Random();
        private Player _player = new Player();
        private Enemy _enemy = new Enemy();
        private FightManager _fightManager = new FightManager();
        private DialogueMethods _dialogue = new DialogueMethods();
        private SaveMethods _save = new SaveMethods();

        public void StartNewGame()
        {
            if (_player.Health == 0) _player.Health = 100;
            PlayerInit();
            while (_player.Health != 0)
            {
                GetRandomEnemy();
                _fightManager.FightCycle(_player, _enemy, _random);
                if (_fightManager.Room != 1)
                {
                    _enemy.AttackDamage++;
                    _enemy.AbilityPower++;
                    _enemy.Defense++;
                }
                _save.SaveGame(_player);
                if (0 == _fightManager.Room % 5) BlacksmithRoom(_player, _random);
            }
        }

        public void StartLoadedGame()
        {
            Console.Clear();
            _player.PlayerWeapon = new LongSword();
            _player.PlayerReset(_player);
            _player = _save.LoadGame(_player);
            while (_player.Health != 0 && _player != null)
            {
                if (_player.AttackDamage == 0) break;
                GetRandomEnemy();
                _fightManager.FightCycle(_player, _enemy, _random);
                if (_fightManager.Room != 1)
                {
                    _enemy.AttackDamage++;
                    _enemy.AbilityPower++;
                    _enemy.Defense++;
                }
                _save.LoadSaveGame(_player);
                if (0 == _player.CurrentRoom % 5 && _player.Health != 5) BlacksmithRoom(_player, _random);
            }
        }

        private void PlayerInit()
        {
            Console.Clear();
            Console.WriteLine("Enter a name: ");
            _player.Name = Console.ReadLine();
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Choose a weapon: ");
                Console.WriteLine("1-LongSword");
                Console.WriteLine("2-Dagger");
                Console.WriteLine("3-Staff");
                try
                {
                    _choose = Convert.ToInt32(Console.ReadLine());
                    switch (_choose)
                    {
                        case 1:
                            _player.PlayerWeapon = new LongSword();
                            break;
                        case 2:
                            _player.PlayerWeapon = new Dagger();
                            break;
                        case 3:
                            _player.PlayerWeapon = new Staff();
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

        private void GetRandomEnemy()
        {
            int randomNumber = _random.Next(1, 4);

            switch (randomNumber)
            {
                case 1:
                    _enemy = new FireAnt();
                    break;
                case 2:
                    _enemy = new TankAnt();
                    break;
                case 3:
                    _enemy = new Ant();
                    break;
                default:
                    _enemy = null;
                    break;
            }
        }

        private void BlacksmithRoom(Player player, Random random)
        {
            Console.Clear();
            Console.WriteLine("Welcome to grasshopper blacksmith:");
            Console.WriteLine(_dialogue.WriteRandomDialogue(random));
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