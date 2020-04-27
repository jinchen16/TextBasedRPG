namespace RPG_SRC.Classes
{
    public enum PowerType
    {
        HEALING,
        INVISIBLE,
        PROTECT,
        SLEEPY,
        NONE
    }

    public class Power : Item
    {
        private PowerType type;
        private int minXP;        

        public PowerType Type { get => type; set => type = value; }
        public int MinXP { get => minXP; set => minXP = value; }

        public Power() : this("None", PowerType.NONE, 0, 0) { }

        public Power(string name, PowerType type, int minXP, int price)
        {
            this.Name = name;
            this.Type = type;
            this.MinXP = minXP;
            this.Price = price;
        }
    }
}
