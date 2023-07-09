using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame
{
    public class Player
    {

        public int Health = 100;
        public int Attack = 5;
        public int Defence = 5;
        public int Strength = 5;
        public int Agility = 5;
        public int Intelligent = 5;
        public string roleType;
        private string Name;

        public void Initialize(string name, string roleType)
        {
            Name = name;
            switch (roleType)
            {
                case "Brawler":
                    Strength = 15;
                    Defence = 15;
                    break;
                case "Wizard":
                    Intelligent = 20;
                    break;
                case "Thief":
                    Agility = 20;
                    break;
            }

            //switchle roletype a göre playerin statlarını başlat.
            //burada canı attagı defansı seçilen role göre STRENGTH AGILITY INTEL ya göre belirle
        }
        public void StartGame()
        {
            Console.WriteLine("TextBasedGame" +
                "\nWelcome the TextBasedGame , enter a name ");
            Name = Console.ReadLine();
            Console.WriteLine("Welcome"+ Name + "\nSelect a class \n1-Brawler\n2-Wizard\n3-Thief");
            roleType = Console.ReadLine();
            Console.WriteLine(roleType + Name);
        }

        public void GetHit()
        {
            //burada can azalıcak işte defansa göre alınan hasar aazalabilir.

            Console.WriteLine(Name + " hasar aldı");
        }

    }
}
