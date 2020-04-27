namespace RPG_SRC.Classes
{
    public interface ILivingEntity
    {
        bool IsDead();
        void ReceiveDamage(int damage);
        void Attack();
    }
}
