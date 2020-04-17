using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_SRC.Classes
{
    public class Monster : LivingEntity
    {
        private string name;
        private int hp;
        private int ap;
        private Player target;

        public int AP { get => ap; set => ap = value; }

        public Monster(string name, int hp, int ap) : base(name, hp)
        {
            this.AP = ap;
        }

        public Monster() : base("None", 0)
        {
            this.AP = 0;
        }

        public override void ReceiveDamage(int damage)
        {
            this.HP -= damage;
        }

        public override void Attack()
        {
            if (target != null)
            {
                target.ReceiveDamage(this.ap);
                if (target.IsDead())
                {
                    // End game here
                }
            }
        }
    }
}
