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
        public int EnemyAttack = 0;
        public int EnemyDefence = 0;
        public Random random = new Random();
        public int damage;

        public void Initialize(string name, string roleType)
        {
            Name = name;
            switch (roleType)
            {
                case "Brawler":
                    Health = 100;
                    Attack = 5;
                    Defence = 5;
                    Strength = 15;
                    Defence = 15;
                    Intelligent = 5;
                    break;
                case "Wizard":
                    Health = 100;
                    Attack = 5;
                    Defence = 5;
                    Intelligent = 20;
                    Strength = 5;
                    Agility = 5;
                    break;
                case "Thief":
                    Health = 100;
                    Attack = 5;
                    Defence = 5;
                    Agility = 20;
                    Strength = 5;
                    Intelligent = 5;
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
            Console.WriteLine("Welcome " + Name + "\n Select a class \n-Brawler\n-Wizard\n-Thief");
            roleType = Console.ReadLine();
        }

        public void GetHit()
        {
            //burada can azalıcak işte defansa göre alınan hasar aazalabilir.
            damage = EnemyAttack - Defence;
            Console.WriteLine(Name + " hasar aldı");
        }

        public void Enemy()
        {
            Health = 100;
            EnemyAttack = random.Next(10);
            EnemyDefence = random.Next(10);

        }



    }
}
