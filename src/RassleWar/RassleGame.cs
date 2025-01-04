using System;
using System.Threading;

namespace RassleWar
{
    public class RassleGame
    {
        int playerHealth = 100;

        int opponentHealth = 100;

        int playerAttackDamage;
        int opponentAttackDamage;


        public string ProcessStartGameResponse(string response)
        {
            response = response.ToUpper();

            if (response == "Y")
            {
                return "Ding! Ding! Ding! The match is underway!";
            }
            else if (response == "N")
            {
                return "To beat the man, you have to have the eye of the tiger! Train hard, take your vitamins, and then come back!";
            }
            else
            {
                return "Keep it clean! Invalid input! Please enter a Y or N!";
            }
        }

        public void BothStandingNeutral()
        {
            Console.WriteLine("And the unstoppable force faces the immovable object!");
            Console.WriteLine("What is the player going to do?");
            Console.WriteLine("1. Lock up with opponent!");
            Console.WriteLine("2. Slap opponent!");
            Console.WriteLine("3. Taunt opponent!");

            if (opponentHealth < 20)
            {
                Console.WriteLine("4. Go for a winning pinfall!");
            }
            else if (playerHealth < 20)
            {
                Console.WriteLine("4. Block opponent's pinfall attempt!");
            }



            var playerMove = Console.ReadLine() ?? string.Empty;
            int playerChoice = int.Parse(playerMove);

            if (playerChoice == 1)
            {
                Console.WriteLine("The two wrestlers lock up in the center of the ring!");

                BothStandingGrappling();
            }
            else if (playerChoice == 2)
            {
                Console.WriteLine("The player slaps the opponent across the face!");
                PerformAttacks();
                BothStandingNeutral();
            }
            else if (playerChoice == 3)
            {
                Console.WriteLine("The player taunts the opponent!");
                BothStandingNeutral();
            }

            else if (playerChoice == 4)
            {
                if (opponentHealth < 20)
                {
                    // Player attempts small package rollup
                    Console.WriteLine("The two wrestlers lock up in the center of the ring! Oh my!"); 
                    Console.WriteLine("The player hooks the opponent's leg while applying a front face lock and reaching aross to grab that other far leg!");
                    Console.WriteLine("The momentum and leverage forces the opponent's shoulders down to the mat!");
                    Console.WriteLine("It's a small package! We've seen this move end matches in the blink of an eye!");
                    Console.WriteLine("The referee counts! This could be it!");
                    Thread.Sleep(1000);
                    Console.Write("1...");
                    Thread.Sleep(1000);
                    Console.Write("2...");
                    Thread.Sleep(1000);
                    Console.WriteLine("3! Got 'em! The player wins!");
                    Environment.Exit(0);
                }
                else if (playerHealth < 20)
                {
                    // Opponent attempts small package rollup
                    Console.WriteLine("The two wrestlers lock up in the center of the ring! Oh my! The opponent sees an opening!");
                    Console.WriteLine("The opponent hook the player's leg while applying a front face lock and reaching across to grab that other far leg!");
                    Console.WriteLine("The momentum and leverage forces the player's shoulders down to the mat!");
                    Console.WriteLine("It's a small package! We've seen this move end matches in the blink of an eye!");
                    Console.WriteLine("The referee counts! This could be it!");
                    Thread.Sleep(1000);
                    Console.Write("1...");
                    Thread.Sleep(1000);
                    Console.Write("2...");
                    Thread.Sleep(1000);
                    Console.WriteLine("3! Got 'em! The opponent wins!");
                    Environment.Exit(0);

                }
            }
        }

        public void BothStandingGrappling()
        {
            Console.WriteLine("What is the player going to do?");
            Console.WriteLine("1. Push opponent into the ropes!");
            Console.WriteLine("2. Try to take opponent down!");
            Console.WriteLine("3. Break the hold!");

            var playerMove = Console.ReadLine() ?? string.Empty;
            int playerChoice = int.Parse(playerMove);

            if (playerChoice == 1)
            {
                Console.WriteLine("The player pushes the opponent into the ropes!");
                BothStandingNeutral();
            }
            else if (playerChoice == 2)
            {
                Console.WriteLine("The player tries to take the opponent down!");
                PerformAttacks();
                BothStandingNeutral();
            }
            else if (playerChoice == 3)
            {
                Console.WriteLine("The player breaks the hold!");
                BothStandingNeutral();
            }

        }

        public void StartGame()
        {
            while (true)
            {
                Console.WriteLine("Are you ready to step in the ring? (Y/N)");
                string response = Console.ReadLine() ?? string.Empty;

                string output = ProcessStartGameResponse(response ?? string.Empty);
                Console.WriteLine(output);

                if (string.Equals(response, "Y", StringComparison.OrdinalIgnoreCase))
                {
                    BothStandingNeutral();
                }

                if (string.Equals(response, "N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Leaving the arena...");
                    break;
                }
            }
        }


        public int GetPlayerAttackPower()
        {
            Random random = new Random();
            int playerAttackPower = random.Next(1, 10);
            return playerAttackPower;
        }

        public int GetOpponentAttackPower()
        {
            Random random = new Random();
            int opponentAttackPower = random.Next(1, 10);
            return opponentAttackPower;
        }

        public int PerformAttacks()
        {
            int playerNumber = GetPlayerAttackPower();
            int opponentNumber = GetOpponentAttackPower();

            if (playerNumber > opponentNumber)
            {
                int opponentAttackDamage = playerNumber - opponentNumber;
                Console.WriteLine("What a maneuver! The player hits the opponent with a powerful move!");
                UpdateOpponentHealth(opponentAttackDamage);
            }
            else if (opponentNumber > playerNumber)
            {
                int playerAttackDamage = opponentNumber - playerNumber;
                Console.WriteLine("The opponent hits the player with a powerful move! What a maneuver!");
                UpdatePlayerHealth(playerAttackDamage);
            }
            else
            {
                Console.WriteLine("It's a stalemate! It's ike two bulls locking horns!");
            }

            CheckGameOver();  // Check wrestler health.


            return 0;
        }

        public void DisplayHealth()
        {
            Console.WriteLine($"Player Health: {playerHealth}");
            Console.WriteLine($"Opponent Health: {opponentHealth}");
        }

        public void UpdatePlayerHealth(int damage)
        {
            playerHealth -= damage;
        }

        public void UpdateOpponentHealth(int damage)
        {
            opponentHealth -= damage;
        }

        public int GetPlayerHealth()
        {
            return playerHealth;
        }

        public int GetOpponentHealth()
        {
            return opponentHealth;
        }

        public void CheckGameOver()
        {
            if (playerHealth <= 0)
            {
                Console.WriteLine("The player is not able to continue! The opponent wins!");
                Environment.Exit(0);
            }
            else if (opponentHealth <= 0)
            {
                Console.WriteLine("The opponent is not able to continue! The player wins!");
                Environment.Exit(0);
            }
        }
    }
}