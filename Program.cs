using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.StartGame();
        }
    }
}
