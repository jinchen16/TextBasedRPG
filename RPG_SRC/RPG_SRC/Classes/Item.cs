using System;
namespace RPG_SRC.Classes
{
    public class Item
    {
        private string name;
        private int price;

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }

        public Item() : this("None", 0) { }

        public Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return Name + ", " + Price;
        }
    }
}