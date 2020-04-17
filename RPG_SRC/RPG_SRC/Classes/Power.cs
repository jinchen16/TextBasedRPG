using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_SRC.Classes
{
    public enum Power_Type
    {
        HEALING,
        INVISIBLE,
        PROTECT
    }

    public class Power
    {
        private string name;
        private Power_Type type;
        private int minXP;

        public string Name { get => name; set => name = value; }
        public Power_Type Type { get => type; set => type = value; }
        public int MinXP { get => minXP; set => minXP = value; }

        public Power(string name, Power_Type type, int minXP)
        {
            this.Name = name;
            this.Type = type;
            this.MinXP = minXP;
        }
    }
}
