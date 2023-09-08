using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame.GameCycle
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
            AttackDamage = 10;
            Defense = 2;
        }
    }

    public class Dagger : Weapon
    {
        public Dagger()
        {
            AttackDamage = 10;
            Defense = 2;
        }
    }

    public class Staff : Weapon
    {
        public Staff()
        {
            AttackDamage = 10;
            Defense = 2;
        }
    }
}
