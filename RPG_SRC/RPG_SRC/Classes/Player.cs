using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_SRC.Classes
{
    public class Player : LivingEntity
    {
        private int hpMax; // Max health points
        private int xp; // Experience points
        private int gp; // Gold points
        private bool isProtected;
        private Monster enemy;
        private List<Power> myPowers;
        private Weapon myWeapon;

        public int HPMax { get => hpMax; set => hpMax = value; }
        public int XP { get => xp; set => xp = value; }
        public int GP { get => gp; set => gp = value; }
        public bool IsProtected { get => isProtected; set => isProtected = value; }
        public Monster Enemy { get => enemy; set => enemy = value; }
        public List<Power> MyPowers { get => myPowers; set => myPowers = value; }
        public Weapon MyWeapon { get => myWeapon; set => myWeapon = value; }

        public Player(string name, int hp, int xp, int gp) : base(name, hp)
        {            
            this.HPMax = hp;
            this.XP = xp;
            this.GP = gp;
            this.IsProtected = false;
            this.Enemy = null;
            this.MyWeapon= null;
            this.MyPowers = new List<Power>();
        }

        public void Heal()
        {
            this.HP = this.HPMax;
        }

        public void Hide()
        {
            Console.WriteLine("You are hidden! You run away!");
            // Display message and call Explore
        }

        public void AddPower(Power p)
        {
            myPowers.Add(p);
        }

        public bool Contains(Power_Type type)
        {
            for (int i = 0; i < myPowers.Count; i++)
            {
                if (myPowers[i].Type == type)
                    return true;
            }
            return false;
        }

        public Power GetPower(Power_Type type)
        {
            for (int i = 0; i < myPowers.Count; i++)
            {
                if (myPowers[i].Type == type)
                    return myPowers[i];
            }
            return null;
        }

        public void ApplyPower(Power_Type type)
        {
            Power power = GetPower(type);
            if (power != null)
            {
                switch (power.Type)
                {
                    case Power_Type.HEALING:
                        Heal();
                        break;
                    case Power_Type.INVISIBLE:
                        Hide();
                        break;
                    case Power_Type.PROTECT:
                        IsProtected = true;
                        break;
                }
            }
        }

        public override void ReceiveDamage(int ap)
        {
            if (IsProtected)
                ap /= 2;
            this.HP -= ap;
        }

        public void UpdateWeapon(Weapon weapon)
        {
            if (MyWeapon.MaxDamage < weapon.MaxDamage)
            {
                MyWeapon = weapon;
            }
        }

        public override void Attack()
        {
            if (enemy != null)
            {
                int minDamage = MyWeapon.MinDamage;
                int maxDamage = MyWeapon.MaxDamage;
                int damageDone = Dice.GetInstance().Next(minDamage, maxDamage + 1);
                enemy.ReceiveDamage(damageDone);
            }
        }
    }
}
