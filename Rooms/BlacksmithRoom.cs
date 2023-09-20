using AntMaze.GameCycle;
using AntMaze.JSON.dialogues;
using System;
using System.Threading;

namespace TextBasedGame.Rooms
{
    public class BlacksmithRoom
    {
        private DialogueMethods _dialogue = new DialogueMethods();
        private int _choose;
        public void CallBlacksmithRoom(Player player)
        {
            Console.Clear();
            Console.WriteLine("Welcome to grasshopper blacksmith:");
            _dialogue.WriteRandomDialogue();
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
