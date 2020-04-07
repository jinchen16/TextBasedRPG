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

    class Power
    {
        private string _name;
        private Power_Type _type;

        public string Name { get => _name; set => _name = value; }
        public Power_Type Type { get => _type; set => _type = value; }

        public Power(string name, Power_Type type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
