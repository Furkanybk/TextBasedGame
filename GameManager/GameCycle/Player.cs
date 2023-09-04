using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame.GameManager.GameCycle
{
    public class Player
    {
        public string Name { get; set; }
        public virtual int Health { get; set; }
        public virtual int AttackDamage { get; set; }
        public virtual int Defense { get; set; }

        public int Hit(int damage)
        {


            return Health;
        }
    }

    public class LongSword : Player
    {
        public override int Health { get { return 120; } set { base.Health = value; } }
        public override int AttackDamage { get { return 20; } set { base.AttackDamage = value; } }
        public override int Defense { get { return 5; } set { base.Defense = value; } }
    }

    public class Dagger : Player
    {
        public override int Health { get { return 100; } set { base.Health = value; } }
        public override int AttackDamage { get { return 10; } set { base.AttackDamage = value; } }
        public override int Defense { get { return 20; } set { base.Defense = value; } }
    }

    public class Staff : Player
    {
        public override int Health { get { return 110; } set { base.Health = value; } }
        public override int AttackDamage { get { return 20; } set { base.AttackDamage = value; } }
        public override int Defense { get { return 10; } set { base.Defense = value; } }
    }
}