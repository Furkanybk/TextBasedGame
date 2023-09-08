using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame.GameCycle
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AbilityPower
        {
            get
            {
                if (PlayerWeapon != null)
                {
                    return _abilityPower + PlayerWeapon.AbilityPower;
                }
                else { return _abilityPower; }
            }
            set => _attackDamage = value;
        }
        public int Agility
        {
            get
            {
                if (PlayerWeapon != null)
                {
                    return _agility + PlayerWeapon.Agility;
                }
                else { return _agility; }
            }
            set => _attackDamage = value;
        }
        public int AttackDamage
        {
            get
            {
                if (PlayerWeapon != null)
                {
                    return _attackDamage + PlayerWeapon.AttackDamage;
                }
                else { return _attackDamage; }
            }

            set => _attackDamage = value;
        }
        public int Defense
        {
            get
            {
                if (PlayerWeapon != null)
                {
                    return _defense + PlayerWeapon.Defense;
                }
                else { return _defense; }
            }

            set => _defense = value;
        }

        public Weapon PlayerWeapon;

        private int _defense;
        private int _attackDamage;
        private int _abilityPower;
        private int _agility;

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
