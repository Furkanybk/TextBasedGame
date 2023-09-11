using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TextBasedGame.GameCycle;

namespace TextBasedGame.JSON.dialogues
{
    public class Dialogue
    {
        public int Id { get; set; }
        public string dialogue { get; set; }

        private int _choose;
        Random random = new Random();

        public string WriteRandomDialogue()
        {
            string json = System.IO.File.ReadAllText("C:/Users/Pofu/Desktop/Projects/GitHub/TextBasedGame/JSON/dialogues/dialogue.json");
            List<Dialogue> dialogues = JsonConvert.DeserializeObject<List<Dialogue>>(json);
            int randomIndex = random.Next(0, dialogues.Count);
            Dialogue randomDialogue = dialogues[randomIndex];
            return randomDialogue.dialogue;
        }

        public void BlacksmithRoom(Player player)
        {
            Console.Clear();
            Console.WriteLine(WriteRandomDialogue());
            Console.WriteLine("Welcome to grasshopper blacksmith:");
            Console.WriteLine(dialogue);
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
        }
    }
}
