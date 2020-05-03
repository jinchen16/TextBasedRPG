namespace RPG_SRC.Classes
{
    public class Monster : LivingEntity
    {
        private int ap;
        private int rxp;
        private Player target;

        public int AP { get => ap; set => ap = value; }
        public int RXP { get => rxp; set => rxp = value; }
        public Player Target { get => target; set => target = value; }

        public Monster(string name, int hp, int ap, int rxp) : base(name, hp)
        {
            this.AP = ap;
            this.RXP = rxp;
        }

        public Monster() : this("None", 0, 0, 0) { }

        public override void ReceiveDamage(int damage)
        {
            this.HP -= damage;
        }

        public override void Attack()
        {
            if (Target != null)
            {
                int damage = Dice.GetInstance().Next(0, this.AP + 1);
                Target.ReceiveDamage(damage);
                if (Target.IsDead())
                {
                    GameManager.GameOver();
                }
            }
        }

        public override string ToString()
        {
            return this.Name + " HP:" + this.HP;
        }
    }
}
