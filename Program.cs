using System;
using System.Collections.Generic;
using System.Linq;
using TextBasedGame.Enemies;

namespace TextBasedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseEnemy enemy = new BaseEnemy();
            BaseEnemy bandit = new BanditEnemy();
            IEnemy interfaceEnemy = new BaseEnemy();

            BaseEnemy castedFromInterface = (BaseEnemy)interfaceEnemy;
            BanditEnemy castedFromInterface2 = (BanditEnemy)interfaceEnemy;

            Console.ReadKey();
        }
    }
}