using System;
using System.Collections.Generic;

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

        public Player() : this("None", 0, 0, 0) { }

        public Player(string name, int hp) : this(name, hp, 0, 0) { }

        public Player(string name, int hp, int xp, int gp) : base(name, hp)
        {
            this.HPMax = hp;
            this.XP = xp;
            this.GP = gp;
            this.IsProtected = false;
            this.Enemy = null;
            this.MyWeapon = new Weapon("Wood Stick", 5, 15, 0);
            this.MyPowers = new List<Power>();
        }

        public void Heal()
        {
            this.HP = this.HPMax;
        }

        public void Hide()
        {
            Console.WriteLine("You are hidden! You run away!");
            this.Enemy = null;
            // Display message and call Explore
        }

        public void Sprinkle()
        {
            // Make the enemy falls sleep            
            if (Enemy is Dragon)
            {
                Dragon dragon = Enemy as Dragon;
                this.GP += dragon.RGP;
                Hide();
            }
            else
            {
                Hide();
            }
        }

        public void AddPower(Power p)
        {
            MyPowers.Add(p);
        }

        public bool Contains(PowerType type)
        {
            for (int i = 0; i < MyPowers.Count; i++)
            {
                if (MyPowers[i].Type == type)
                    return true;
            }
            return false;
        }

        public Power GetPower(PowerType type)
        {
            for (int i = 0; i < MyPowers.Count; i++)
            {
                if (MyPowers[i].Type == type)
                    return MyPowers[i];
            }
            return null;
        }

        public void ApplyPower(PowerType type)
        {
            Power power = GetPower(type);
            if (power != null && this.XP >= power.MinXP)
            {
                MyPowers.Remove(power);
                switch (power.Type)
                {
                    case PowerType.HEALING:
                        Heal();
                        break;
                    case PowerType.INVISIBLE:
                        Hide();
                        break;
                    case PowerType.PROTECT:
                        IsProtected = true;
                        break;
                    case PowerType.SLEEPY:
                        Sprinkle();
                        break;
                }
            }
            else if (power == null)
            {
                Message.Warning("You don't have the " + type + " power");
            }
            else
            {
                Message.Warning("You don't have enough experience for " + type);
            }
        }

        public override void ReceiveDamage(int ap)
        {
            if (IsProtected)
                ap /= 2;

            if (ap == 0)
            { 
                Message.Success("Damage dodged");
            }
            else
            {                
                this.HP -= ap;
            }            
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
            if (Enemy != null)
            {
                int minDamage = MyWeapon.MinDamage;
                int maxDamage = MyWeapon.MaxDamage;
                int damageDone = Dice.GetInstance().Next(minDamage, maxDamage + 1);
                Enemy.ReceiveDamage(damageDone);

                if (Enemy.IsDead())
                {
                    this.XP += Enemy.RXP;
                    if (Enemy is Dragon)
                    {
                        this.GP += ((Dragon)Enemy).RGP;
                    }
                }
            }
        }

        public void BuyItem(Item item)
        {
            if (this.GP >= item.Price)
            {
                this.GP -= item.Price;
                if (item is Weapon)
                {
                    UpdateWeapon(item as Weapon);
                }
                else if (item is Power)
                {
                    MyPowers.Add(item as Power);
                }
            }
            else
            {
                Message.Warning("Not enough gold to buy " + item.Name);
            }
        }

        public override string ToString()
        {
            return this.Name + " HP: " + this.HP + "/" + this.HPMax + " XP: " + this.XP + " GP: " + this.GP;
        }
    }
}
