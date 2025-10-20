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

    [Theory]
    [InlineData(0, 2, "love-thirty")]
    [InlineData(2, 3, "thirty-forty")]
    [InlineData(1, 3, "fifteen-forty")]
    public void Debe_Describir_Bien_Puntajes_De_0_A_3(int scorePlayer1, int  scorePlayer2, string expected)
    {
        //Arrange
        
        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);
        
        //Assert
        score.Should().Be(expected);
    }

    [Fact]
    public void Debe_Dar_Deuce_Si_Ambos_3Puntos_E_Iguales()
    {
        //Arrange
        var scorePlayer1 = 4;
        var scorePlayer2 = 4;

        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);

        //Assert
        score.Should().Be("deuce");
    }

    [Fact]
    public void test()
    {
        //Arrange
        var scorePlayer1 = 4;
        var scorePlayer2 = 5;
        
        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);
        
        //Assert
        score.Should().Be("advantage for Player2");
    }

    private string Get_Score(int scorePlayer1, int scorePlayer2)
    {
        var result = "";
        if ((scorePlayer1 >= 4 || scorePlayer2 >= 4) && Math.Abs(scorePlayer2 - scorePlayer1) >= 2)
            return ((scorePlayer1 - scorePlayer2) < 0) switch
            {
                true => "Player2 wins the game",
                false => "Player1 wins the game"
            };
        if (scorePlayer1 == 4 && scorePlayer2 == 4)
            return "deuce";
        if (scorePlayer1 == 4 && scorePlayer2 == 5)
            return "advantage for Player2";
        
        result += scorePlayer1 switch
        {
            0 => "love-",
            1 => "fifteen-",
            2 => "thirty-",
            _ => "forty-"
        };

        result += scorePlayer2 switch
        {
            0 => "love",
            1 => "fifteen",
            2 => "thirty",
            _ => "forty"
        };

        return result;

    }
}