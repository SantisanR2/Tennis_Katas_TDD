using AwesomeAssertions;

namespace Tennis;

public class TennisTest
{
    [Theory]
    [InlineData(0, 4, "Player2 wins the game")]
    [InlineData(2, 4, "Player2 wins the game")]
    [InlineData(6, 4, "Player1 wins the game")]
    public void Debe_Ganar_Si_4Puntos_Y_2_Arriba(int scorePlayer1, int  scorePlayer2, string expected)
    {
        //Arrange

        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);
        
        //Assert
        score.Should().Be(expected);
    }

    [Fact]
    public void Debe_Describir_Bien_Puntajes_De_0_A_3()
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
        if ((scorePlayer1 < 4 && scorePlayer2 < 4) || Math.Abs(scorePlayer2 - scorePlayer1) < 2) 
            return "love-thirty";
        return ((scorePlayer1 - scorePlayer2) < 0) switch
        {
            true => "Player2 wins the game",
            false => "Player1 wins the game"
        };
    }
}