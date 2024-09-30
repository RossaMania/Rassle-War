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

        public void RasslingMatch()
        {
            Console.WriteLine("And the unstoppable force faces the immovable object!");
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
                    RasslingMatch();
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