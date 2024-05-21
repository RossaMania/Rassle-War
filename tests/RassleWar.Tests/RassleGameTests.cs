using Xunit;

namespace RassleWar.Tests
{
    public class RassleGameTests
    {
        [Fact]
        public void StartGame_ReturnsCorrectMessage()
        {
            // Arrange
            var game = new RassleGame();

            // Act
            var result = game.StartGame();

            // Assert
            Assert.Equal("The game has started!", result);
        }
    }
}