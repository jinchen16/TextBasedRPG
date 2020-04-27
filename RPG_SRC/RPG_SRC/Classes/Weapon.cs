namespace RPG_SRC.Classes
{
    public class Weapon : Item
    {
        private int minDamage;
        private int maxDamage;

        public int MinDamage { get => minDamage; set => minDamage = value; }
        public int MaxDamage { get => maxDamage; set => maxDamage = value; }

        // Constructor
        public Weapon() : this("None", 0, 0, 0) { }

        public Weapon(string name, int minDamage, int maxDamage, int price)
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Price = price;
        }

        // The damage done would be a random value between the min and max
        public int Damage()
        {
            return 0;
        }
    }
}
