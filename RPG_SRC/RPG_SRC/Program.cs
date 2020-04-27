using System;
using RPG_SRC.Classes;

namespace RPG_SRC
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            string playerName;

            Console.WriteLine("Enter the name of your player");
            Console.WriteLine();
            playerName = Console.ReadLine();
            GameManager.StartGame(playerName);

            Console.WriteLine("---- FOREST ADVENTURE GAME ----");
            do
            {
                Console.WriteLine(GameManager.CurrentPlayer.ToString());
                Console.WriteLine();
                Message.Success("Menu of Commands: L = Look Around | A = Attack | B  = Buy Items | Q = Quit");
                Message.Success("Menu of Powers: H = Healing | I = Invisible | P  = Protect | S = Sleepy");

                input = Console.ReadKey();                
                Console.WriteLine();
                Explore(input.Key);
            }
            while (input.Key != ConsoleKey.Q && !GameManager.gameOver);

            GameManager.SaveGame();
            Console.ReadKey();
        }

        public static void Explore(ConsoleKey key)
        {
            // L = look arround
            if (key == ConsoleKey.L)
            {
                if (GameManager.CurrentPlayer.Enemy == null)
                {
                    GameManager.Explore();
                }
                else
                {
                    Message.Danger("There's an enemy in front of you!");
                    GameManager.CurrentPlayer.Enemy.Attack();
                    Message.Danger("You were hit!");
                    if (GameManager.CurrentPlayer.IsDead())
                    {
                        GameManager.GameOver();
                    }
                }
            }
            // A = attack
            if (key == ConsoleKey.A)
            {
                if (GameManager.CurrentPlayer.Enemy == null)
                {
                    Message.Danger("There's no enemy to attack!");
                }
                else
                {
                    GameManager.StartBattle();
                    if (GameManager.CurrentPlayer.Enemy != null && !GameManager.CurrentPlayer.IsDead())
                    {
                        if (GameManager.CurrentPlayer.IsDead())
                        {
                            GameManager.GameOver();
                        }
                    }
                }
            }
            // H = healing power
            if (key == ConsoleKey.H)
            {
                GameManager.CurrentPlayer.ApplyPower(PowerType.HEALING);
            }
            // I = invisible power
            if (key == ConsoleKey.I)
            {
                GameManager.CurrentPlayer.ApplyPower(PowerType.INVISIBLE);
            }
            // P = protect power
            if (key == ConsoleKey.P)
            {
                GameManager.CurrentPlayer.ApplyPower(PowerType.PROTECT);
            }
            // S = sleepy
            if (key == ConsoleKey.S)
            {
                GameManager.CurrentPlayer.ApplyPower(PowerType.SLEEPY);
            }
            // B = buy items
            if (key == ConsoleKey.B)
            {
                Power healing = GameFactory.CreateHealing();
                Power invisible = GameFactory.CreateInvisible();
                Power protect = GameFactory.CreateProtect();
                Power sleepy = GameFactory.CreateSleepy();
                Message.Warning("Store Powers: H = Healing " + healing.Price + " | I = Invisible " + invisible.Price + " | P = Protect " + protect.Price + " | S = Sleeepy " + sleepy.Price);
                Weapon rock = GameFactory.CreateRock();
                Weapon torch = GameFactory.CreateTorch();
                Weapon sword = GameFactory.CreateSword();
                Message.Warning("Store Weapons: R = Big Rock " + rock.Price + " | T = Torch " + torch.Price + " | M = Magic Sword " + sword.Price);

                ConsoleKeyInfo buyCommand = Console.ReadKey();
                switch (buyCommand.Key)
                {
                    case ConsoleKey.H:
                        GameManager.CurrentPlayer.BuyItem(healing);
                        break;
                    case ConsoleKey.I:
                        GameManager.CurrentPlayer.BuyItem(invisible);
                        break;
                    case ConsoleKey.P:
                        GameManager.CurrentPlayer.BuyItem(protect);
                        break;
                    case ConsoleKey.S:
                        GameManager.CurrentPlayer.BuyItem(sleepy);
                        break;
                    case ConsoleKey.R:
                        GameManager.CurrentPlayer.BuyItem(rock);
                        break;
                    case ConsoleKey.T:
                        GameManager.CurrentPlayer.BuyItem(torch);
                        break;
                    case ConsoleKey.M:
                        GameManager.CurrentPlayer.BuyItem(sword);
                        break;
                    default:
                        Message.Danger("Wrong command!");
                        break;
                }
            }
        }
    }
}
