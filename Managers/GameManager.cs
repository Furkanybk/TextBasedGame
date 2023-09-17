using System;
using System.Threading;
using AntMaze.GameCycle;
using AntMaze.JSON.dialogues;
using AntMaze.JSON.Save;
using TextBasedGame.Rooms;

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
        private BlacksmithRoom room = new BlacksmithRoom();

        public void StartNewGame()
        {
            if (_player.Health == 0) _player.Health = 100;
            _player.PlayerInit(_player);
            while (_player.Health != 0)
            {
                _enemy.GetRandomEnemy(_enemy, _random);
                _fightManager.FightCycle(_player, _enemy, _random);
                if (_fightManager.Room != 1)
                {
                    _enemy.AttackDamage++;
                    _enemy.AbilityPower++;
                    _enemy.Defense++;
                }
                _save.SaveGame(_player);
                if (0 == _fightManager.Room % 5) room.CallBlacksmithRoom(_player, _random);
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
                _enemy.GetRandomEnemy(_enemy, _random);
                _fightManager.FightCycle(_player, _enemy, _random);
                if (_fightManager.Room != 1)
                {
                    _enemy.AttackDamage++;
                    _enemy.AbilityPower++;
                    _enemy.Defense++;
                }
                _save.LoadSaveGame(_player);
                if (0 == _player.CurrentRoom % 5 && _player.Health != 5) room.CallBlacksmithRoom(_player, _random);
            }
        }
    }
}
