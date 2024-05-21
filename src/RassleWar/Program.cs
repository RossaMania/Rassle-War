using System;

namespace RassleWar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rassle War!");
            // You can create an instance of RassleGame and start the game
            var game = new RassleGame();
            Console.WriteLine(game.StartGame());
        }
    }
}