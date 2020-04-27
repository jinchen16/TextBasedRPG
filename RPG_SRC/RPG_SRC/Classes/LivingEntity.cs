namespace RPG_SRC.Classes
{
    public abstract class LivingEntity : ILivingEntity
    {
        private string name;
        private int hp;
        public string Name { get => name; set => name = value; }
        public int HP { get => hp; set => hp = value; }

        public LivingEntity() : this("None", 0) { }

        public LivingEntity(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
        }

        public bool IsDead()
        {
            if (HP <= 0)
                return true;
            return false;
        }

        public virtual void ReceiveDamage(int damage)
        {
            HP -= damage;
        }

        public abstract void Attack();
    }
}
