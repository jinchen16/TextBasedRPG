using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_SRC.Classes
{
    class Player
    {
        private string _name;
        private int _hp; // Health points
        private int _hpMax; // Max health points
        private int _xp; // Experience points
        private int _gp; // Gold points
        private bool _isProtected;
        private Monster _enemy;
        private List<Power> _myPowers;
        private Weapon _myWeapon;

        public string Name { get => _name; set => _name = value; }
        public int HP { get => _hp; set => _hp = value; }
        public int HPMax { get => _hpMax; set => _hpMax = value; }
        public int XP { get => _xp; set => _xp = value; }
        public int GP { get => _gp; set => _gp = value; }
        public bool IsProtected { get => _isProtected; set => _isProtected = value; }
        public Monster Enemy { get => _enemy; set => _enemy = value; }
        public Weapon MyWeapon { get => _myWeapon; set => _myWeapon = value; }

        public Player()
        {
            _myPowers = new List<Power>();
            this.Name = "None";
            this.HPMax = 10;
            this.HP = this.HPMax;
            this.XP = 0;
            this.GP = 0;
            this.IsProtected = false;
            this.Enemy = null;
            this.MyWeapon = null;
        }

        public Player(int hp, int hpMax, int xp)
        {
            this.HP = hp;
            this.HPMax = hpMax;
            this.XP = xp;
        }

        public bool IsDead()
        {
            if (this.HP <= 0)
                return true;
            return false;
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
            _myPowers.Add(p);
        }

        public bool Contains(Power_Type type)
        {
            for (int i = 0; i < _myPowers.Count; i++)
            {
                if (_myPowers[i].Type == type)
                    return true;
            }
            return false;
        }

        public void ApplyPower(Power_Type type)
        {
            if (Contains(type))
            {
                switch (type)
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
                    default:
                        break;
                }
            }
        }

        public void ReceiveDamage(int ap)
        {
            if (IsProtected)
                ap /= 2;
            this.HP -= ap;
        }

        public void UpdateWeapon(Weapon weapon)
        {
            if (_myWeapon.MaxDamage < weapon.MaxDamage)
            {
                _myWeapon = weapon;
            }
        }
    }
}
