using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntMaze.GameCycle
{
    public abstract class Weapon 
    {
        public int AttackDamage;
        public int Defense;
        public int Agility;
        public int AbilityPower;
    }

    public class LongSword : Weapon
    {
        public LongSword()
        {
            AttackDamage = 15;
            Defense = 2;
            Agility = 3;
            AbilityPower = 9;
        }
    }

    public class Dagger : Weapon
    {
        public Dagger()
        {
            AttackDamage = 10;
            Defense = 2;
            Agility = 7;
            AbilityPower= 8;
        }
    }

    public class Staff : Weapon
    {
        public Staff()
        {
            AbilityPower = 16;
            AttackDamage = 8;
            Defense = 5;
            Agility = 2;
        }
    }
}
