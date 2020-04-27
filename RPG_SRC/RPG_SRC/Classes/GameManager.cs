using System;
using System.Collections.Generic;

namespace RPG_SRC.Classes
{
    public static class GameManager
    {
        public static List<Player> LPlayers = new List<Player>();
        public static Player CurrentPlayer;
        public static bool gameOver = false;
        private static int BattleRounds = 0;
        private static readonly int MaxRounds = 5;

        public static void StartGame(string name)
        {
            try
            {
                GameManager.LPlayers = DataXML.Load("Scores.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception error=>" + e.Message);
            }

            Player player = SearchPlayer(name);
            if (player != null)
            {
                if (player.IsDead())
                {
                    CurrentPlayer = new Player(name, 100);
                }
                else
                {
                    CurrentPlayer = player;
                }
            }
            else
            {
                CurrentPlayer = new Player(name, 100);
            }
        }

        public static Player SearchPlayer(string name)
        {
            foreach (Player player in LPlayers)
            {
                if (String.Compare(player.Name, name, true) == 0)
                {
                    return player;
                }
            }
            return null;
        }

        public static void GameOver()
        {
            gameOver = true;
            Console.WriteLine("Game over!");
        }

        public static void SaveGame()
        {
            CurrentPlayer.Enemy = null;
            Player player = SearchPlayer(CurrentPlayer.Name);
            if (player != null)
            {
                if (player.GP < CurrentPlayer.GP || player.IsDead())
                {
                    LPlayers.Remove(player);
                    LPlayers.Add(CurrentPlayer);
                }                
            }
            else
            {
                LPlayers.Add(CurrentPlayer);
            }
            DataXML.Save("Scores.xml", LPlayers);
        }

        public static void StartBattle()
        {
            Console.WriteLine("You're fighting against " + GameManager.CurrentPlayer.Enemy.Name);
            GameManager.CurrentPlayer.Attack();
            BattleRounds++;

            System.Threading.Thread.Sleep(1000); // Waiting for one second

            if (GameManager.CurrentPlayer.Enemy != null && GameManager.CurrentPlayer.Enemy.IsDead())
            {
                Message.Danger("Your enemy is dead!");
                BattleRounds = 0;
                GameManager.CurrentPlayer.Enemy = null;
                GameManager.Explore();
            }
            else
            {
                Message.Danger("Your enemy is not dead!");
                if (BattleRounds >= MaxRounds)
                {
                    Message.Danger("You panicked and run away...");
                    GameManager.CurrentPlayer.Enemy = null;
                    BattleRounds = 0;
                    GameManager.Explore();
                }
                else
                {
                    // Enemy attacking the player
                    GameManager.CurrentPlayer.Enemy.Attack();
                    Message.Danger("\n" + GameManager.CurrentPlayer.Enemy.Name + " is attacking you...");
                }
            }
        }

        public static void Explore()
        {
            Dice dice = Dice.GetInstance();
            int random = dice.Next(0, 15);
            Console.WriteLine("You're exploring... ");
            switch (random)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    Monster monster = GameFactory.CreateMonster();
                    Message.Danger(monster.Name + " approaches!  Prepare for battle!");
                    monster.Target = GameManager.CurrentPlayer;
                    GameManager.CurrentPlayer.Enemy = monster;
                    break;
                case 4:
                    Message.Warning("\nYou have collected a Magic Potion!");
                    Power magicPotion = GameFactory.CreateHealing();                    
                    GameManager.CurrentPlayer.AddPower(magicPotion);
                    break;
                case 5:
                    Message.Warning("\nYou have collected a Magic Cape!");
                    Power magicCape = GameFactory.CreateInvisible();
                    GameManager.CurrentPlayer.AddPower(magicCape);
                    break;
                case 6:
                    Message.Warning("\nYou have collected a Wood Shield!");
                    Power woodShield= GameFactory.CreateProtect();
                    GameManager.CurrentPlayer.AddPower(woodShield);
                    break;
                case 7:
                    Message.Warning("\nYou have collected a Sleepy Dust!");
                    Power sleepyDust = GameFactory.CreateSleepy();
                    GameManager.CurrentPlayer.AddPower(sleepyDust);
                    break;
                case 8:
                    Message.Warning("\nYou have found a Big Rock!");
                    Weapon rock = GameFactory.CreateRock();
                    GameManager.CurrentPlayer.UpdateWeapon(rock);
                    break;
                case 9:
                    Message.Warning("\nYou have found a Torch!");
                    Weapon torch = GameFactory.CreateTorch();
                    GameManager.CurrentPlayer.UpdateWeapon(torch);
                    break;
                case 10:
                    Message.Warning("\nYou have found a Magic Sword!");
                    Weapon sword = GameFactory.CreateSword();
                    GameManager.CurrentPlayer.UpdateWeapon(sword);
                    break;
                case 11:
                    int randomGP = Dice.GetInstance().Next(50, 500);
                    Message.Warning("\nYou have collected " + randomGP + " gold pieces!");
                    GameManager.CurrentPlayer.GP += randomGP;
                    break;
                default:
                    Console.WriteLine("\nYou are looking for gold pieces!");
                    break;
            }
        }
    }
}
