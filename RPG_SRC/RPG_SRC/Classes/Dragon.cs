namespace RPG_SRC.Classes
{
    public class Dragon : Monster
    {
        private int rgp;

        public int RGP { get => rgp; set => rgp = value; }

        public Dragon() : this("None", 0, 0, 0) { this.RGP = 0; }

        public Dragon(string name, int hp, int ap, int rxp) : base(name, hp, ap, rxp)
        {
            this.RGP = Dice.GetInstance().Next(1000, 10001);
        }
    }
}
