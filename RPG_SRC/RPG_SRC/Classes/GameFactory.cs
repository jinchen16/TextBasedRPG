namespace RPG_SRC.Classes
{
    public static class GameFactory
    {
        public static Monster CreateMonster()
        {
            int random = Dice.GetInstance().Next(0, 100);
            if (random <= 10)
            {
                return new Dragon("Mystic Dragon", 120, 40, 3);
            }
            else if (random > 10 && random <= 30)
            {
                return new Monster("Ogre", 80, 40, 2);
            }
            return new Monster("Goblin", 40, 10, 1);
        }

        public static Power CreateHealing()
        {
            return new Power("Magic Potion", PowerType.HEALING, 2, 200);
        }

        public static Power CreateInvisible()
        {
            return new Power("Magic Cape", PowerType.INVISIBLE, 3, 300);
        }

        public static Power CreateProtect()
        {
            return new Power("Wood Shield", PowerType.PROTECT, 1, 100);
        }

        public static Power CreateSleepy()
        {
            return new Power("Sleepy Dust", PowerType.SLEEPY, 6, 600);
        }

        public static Weapon CreateRock()
        {
            return new Weapon("Big Rock", 20, 30, 100);
        }

        public static Weapon CreateTorch()
        {
            return new Weapon("Torch", 35, 45, 300);
        }

        public static Weapon CreateStick()
        {
            return new Weapon("Wood Stick", 5, 15, 0);
        }

        public static Weapon CreateSword()
        {
            return new Weapon("Magic Sword", 50, 60, 500);
        }
    }
}
