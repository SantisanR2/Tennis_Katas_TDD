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

    [Theory]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(7, 7)]
    public void Debe_Dar_Deuce_Si_Ambos_3Puntos_E_Iguales(int scorePlayer1, int  scorePlayer2)
    {
        //Arrange

        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);

        //Assert
        score.Should().Be("deuce");
    }

    [Theory]
    [InlineData(4, 5, "advantage for Player2")]
    [InlineData(6, 7, "advantage for Player2")]
    [InlineData(9, 8, "advantage for Player1")]
    public void Debe_Describir_Bien_Ventaja_Si_Ambos_3_Y_1Punto_Arriba(int scorePlayer1, int  scorePlayer2, string expected)
    {
        //Arrange
        
        //Act
        var score = Get_Score(scorePlayer1, scorePlayer2);
        
        //Assert
        score.Should().Be(expected);
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
        
        if (scorePlayer1 == scorePlayer2)
            return "deuce";
        
        if ((scorePlayer1 >= 3 && scorePlayer2 >= 3) && Math.Abs(scorePlayer2 - scorePlayer1) == 1)
            return ((scorePlayer1 - scorePlayer2) < 0) switch
            {
                true => "advantage for Player2",
                false => "advantage for Player1"
            };
        
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