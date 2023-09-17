using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntMaze.GameCycle
{
    public abstract class Character
    {
        public string Name;
        public int Health;
        public int AbilityPower
        {
            get
            {
                if (PlayerWeapon != null)
                {
                    return WeaponAgilityPower + PlayerWeapon.AbilityPower;
                }
                else { return WeaponAgilityPower; }
            }
            set => WeaponAttackDamage = value;
        }
        public int Agility
        {
            get
            {
                if (PlayerWeapon != null)
                {
                    return WeaponAgility + PlayerWeapon.Agility;
                }
                else { return WeaponAgility; }
            }
            set => WeaponAttackDamage = value;
        }
        public int AttackDamage
        {
            get
            {
                if (PlayerWeapon != null)
                {
                    return WeaponAttackDamage + PlayerWeapon.AttackDamage;
                }
                else { return WeaponAttackDamage; }
            }

            set => WeaponAttackDamage = value;
        }
        public int Defense
        {
            get
            {
                if (PlayerWeapon != null)
                {
                    return WeaponDefense + PlayerWeapon.Defense;
                }
                else { return WeaponDefense; }
            }

            set => WeaponDefense = value;
        }

        public Weapon PlayerWeapon;

        public int WeaponDefense;
        public int WeaponAttackDamage;
        public int WeaponAgilityPower;
        public int WeaponAgility;

        public Character()
        {
            Health = 100;
            AttackDamage = 3;
            Defense = 2;
            Agility = 3;
            AbilityPower = 3;
        }

        public void CounterAttack(Character character)
        {
            int attack = 2 / Defense + AttackDamage;
            attack -= character.Defense;
            attack = attack < 0 ? 0 : attack;
            character.GetHit(attack);

        }

        public void MagicAttack(Character character)
        {
            int attack = AbilityPower;
            attack -= character.Defense;
            attack = attack < 0 ? 0 : attack;
            character.GetHit(attack);
        }

        public void Attack(Character character)
        {
            int attack = AttackDamage;
            attack -= character.Defense;
            attack = attack < 0 ? 0 : attack;
            character.GetHit(attack);

        }

        public virtual void GetHit(int damage)
        {
            Health -= damage;
            Health = Health < 0 ? 0 : Health;
        }
    }
}
