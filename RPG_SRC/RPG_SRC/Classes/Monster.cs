using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_SRC.Classes
{
    class Monster
    {
        private string _name;
        private int _hp;
        private int _ap;

        public string Name { get => _name; set => _name = value; }
        public int HP { get => _hp; set => _hp = value; }
        public int AP { get => _ap; set => _ap = value; }

        public Monster(string name, int hp, int ap)
        {
            this.Name = name;
            this.HP = hp;
            this.AP = ap;
        }

        public Monster()
        {
            this.Name = "None";
            this.HP = 0;
            this.AP = 0;
        }

        public bool IsDead()
        {
            if (this.HP <= 0)
                return true;
            return false;
        }

        public void ReceiveDamage(Player target)
        {
            this.HP -= target.MyWeapon.Damage();
        }

        public void Attack(Player target)
        {
            target.ReceiveDamage(this._ap);
            if (target.IsDead())
            {
                // End game here
            }
        }
    }
}
