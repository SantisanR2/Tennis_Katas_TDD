using AwesomeAssertions;

namespace Tennis;

public class TennisTest
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var scorePlayer1 = 0;
        var scorePlayer2 = 4;

        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);
        
        //Assert
        score.Should().Be("Player2 wins the game");
    }

    private object Get_Score(int scorePlayer1, int scorePlayer2)
    {
        return "Player2 wins the game";
    }
}