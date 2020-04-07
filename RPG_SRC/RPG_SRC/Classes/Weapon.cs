using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_SRC.Classes
{
    class Weapon
    {
        private string _name;
        private int _minDamage;
        private int _maxDamage;

        private Random rand = new Random();

        public string Name { get => _name; set => _name = value; }
        public int MinDamage { get => _minDamage; set => _minDamage = value; }
        public int MaxDamage { get => _maxDamage; set => _maxDamage = value; }

        // Constructor
        public Weapon()
        {
            this.Name = "None";
            this.MinDamage = 0;
            this.MaxDamage = 0;
        }

        public Weapon(string name, int minDamage, int maxDamage)
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
        }

        // The damage done would be a random value between the min and max
        public int Damage()
        {
            return rand.Next(_minDamage, _maxDamage + 1);
        }
    }
}
