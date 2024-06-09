using System;

namespace RassleWar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rassle War!");
            var game = new RassleGame();
            game.StartGame();
        }
    }
}