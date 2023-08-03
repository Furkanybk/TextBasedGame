using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame.Managers
{
    public class FightCycle
    {

        private Player _player = new Player();
        private Enemy _enemy = new Enemy();

        public void StartFight(Player player, Enemy enemy)
        {
            _player = player;
             Update();
        }

        public void Update()
        {
            while (_player.Health > 0 && _enemy.Health > 0)
            {
                Console.WriteLine("1) Attack");
                Console.Write("\r\nSelect an option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        _enemy.Health = _enemy.GetHit(_player.Damage);
                        Console.WriteLine("The enemy has " + _enemy.Health + " health left.");
                        _player.Health = _player.GetHit(_enemy.Attack);
                        Console.WriteLine("You have " + _player.Health + " health left.");
                        break;
                    default:
                        Console.Write("Please choose valid option");
                        break;
                }
            }
        }

        public void EndFight()
        {
            Console.WriteLine("oyun bitti");
            Console.ReadKey();
        }
    }
}

