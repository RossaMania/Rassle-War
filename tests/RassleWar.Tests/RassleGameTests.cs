using Xunit;
using System;

namespace RassleWar.Tests
{
    public class RassleGameTests
    {
        [Fact]
        public void ProcessStartGameResponse_WhenResponseIsY_ReturnsMatchIsUnderway()
        {
            // Arrange
            var game = new RassleGame();
            string response = "Y";

            // Act
            string result = game.ProcessStartGameResponse(response);

            // Assert
            Assert.Equal("Ding! Ding! Ding! The match is underway!", result);
        }

        [Fact]
        public void ProcessStartGameResponse_WhenResponseIsN_ReturnsTrainHardMessage()
        {
            // Arrange
            var game = new RassleGame();
            string response = "N";

            // Act
            string result = game.ProcessStartGameResponse(response);

            // Assert
            Assert.Equal("To beat the man, you have to have the eye of the tiger! Train hard, take your vitamins, and then come back!", result);
        }

        [Fact]
        public void ProcessStartGameResponse_WhenResponseIsInvalid_ReturnsInvalidInputMessage()
        {
            // Arrange
            var game = new RassleGame();
            string response = "Invalid";

            // Act
            string result = game.ProcessStartGameResponse(response);

            // Assert
            Assert.Equal("Keep it clean! Invalid input! Please enter a Y or N!", result);
        }

        [Fact]
        public void StartGame_WhenResponseIsY_BreaksLoop()
        {
            // Arrange
            var game = new RassleGame();
            string response = "Y";
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            using (var consoleInput = new System.IO.StringReader(response))
            {
                Console.SetIn(consoleInput);
                game.StartGame();
            }

            // Assert
            Assert.Contains("Are you ready to step in the ring? (Y/N)", consoleOutput.ToString());
            Assert.Contains("Ding! Ding! Ding! The match is underway!", consoleOutput.ToString());
        }

        [Fact]
        public void StartGame_WhenResponseIsN_BreaksLoop()
        {
            // Arrange
            var game = new RassleGame();
            string response = "N";
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            using (var consoleInput = new System.IO.StringReader(response))
            {
                Console.SetIn(consoleInput);
                game.StartGame();
            }

            // Assert
            Assert.Contains("Are you ready to step in the ring? (Y/N)", consoleOutput.ToString());
            Assert.Contains("To beat the man, you have to have the eye of the tiger! Train hard, take your vitamins, and then come back!", consoleOutput.ToString());
        }
    }
}