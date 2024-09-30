using System;

namespace RassleWar
{
    public class RassleGame
    {
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
                BothStandingNeutral();
            }
            else if (playerChoice == 3)
            {
                Console.WriteLine("The player taunts the opponent!");
                BothStandingNeutral();
            }
        }

        public void BothStandingGrappling()
        {
            Console.WriteLine("The two wrestlers are locked up in the center of the ring!");
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
    }
}