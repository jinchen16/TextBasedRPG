using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_SRC.Classes
{
    public class Weapon
    {
        private string name;
        private int minDamage;
        private int maxDamage;

        private Random rand = new Random();

        public string Name { get => name; set => name = value; }
        public int MinDamage { get => minDamage; set => minDamage = value; }
        public int MaxDamage { get => maxDamage; set => maxDamage = value; }

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
            return rand.Next(minDamage, maxDamage + 1);
        }
    }
}
