using System;

namespace RPG_SRC.Classes
{
    public class Dice : Random
    {
        private static Dice instance = null;
        private Dice() : base() { }
        public static Dice GetInstance()
        {
            if (instance == null)
            {
                instance = new Dice();
            }
            return instance;
        }
    }
}
