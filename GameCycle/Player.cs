using System;
using System.Threading;

namespace AntMaze.GameCycle
{
    public class Player : Character
    {
        public int Id;
        public int CurrentRoom;
        public override void GetHit(int damage)
        {
            base.GetHit(damage);
            Console.WriteLine($"You took {damage} damage");
            Thread.Sleep(2000);
        }

        public Player PlayerReset(Player player) 
        {
            player.WeaponDefense = 0;
            player.WeaponAgilityPower = 0;
            player.WeaponDefense = 0;
            player.WeaponAttackDamage = 0;
            player.PlayerWeapon.AttackDamage = 0;
            player.PlayerWeapon.Agility = 0;
            player.PlayerWeapon.Defense = 0;
            player.PlayerWeapon.AbilityPower = 0;
            return player;
        }
    }
}