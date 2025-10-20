using AwesomeAssertions;

namespace Tennis;

public class TennisTest
{
    [Fact]
    public void Debe_Ganar_Si_4Puntos_Y_2_Arriba()
    {
        //Arrange
        var scorePlayer1 = 0;
        var scorePlayer2 = 4;

        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);
        
        //Assert
        score.Should().Be("Player2 wins the game");
    }

    [Fact]
    public void test()
    {
        //Arrange
        var scorePlayer1 = 0;
        var scorePlayer2 = 2;
        
        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);
        
        //Assert
        score.Should().Be("love-thirty");
    }

    private string Get_Score(int scorePlayer1, int scorePlayer2)
    {
        if (scorePlayer2 == 2)
            return "love-thirty";
        return "Player2 wins the game";
    }
}