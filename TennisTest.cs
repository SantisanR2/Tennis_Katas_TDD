using AwesomeAssertions;

namespace Tennis;

public class TennisTest
{
    private readonly TennisGame _game = new();

    [Theory]
    [InlineData(0, 4, "Player2 wins the game")]
    [InlineData(2, 4, "Player2 wins the game")]
    [InlineData(6, 4, "Player1 wins the game")]
    public void Debe_Ganar_Si_4Puntos_Y_2_Arriba(int scorePlayer1, int scorePlayer2, string expected)
    {
        //Act
        var score = _game.GetScore(scorePlayer1, scorePlayer2);
        //Assert
        score.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 2, "love-thirty")]
    [InlineData(2, 3, "thirty-forty")]
    [InlineData(1, 3, "fifteen-forty")]
    public void Debe_Describir_Bien_Puntajes_De_0_A_3(int scorePlayer1, int scorePlayer2, string expected)
    {
        //Act
        var score = _game.GetScore(scorePlayer1, scorePlayer2);
        //Assert
        score.Should().Be(expected);
    }

    [Theory]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(7, 7)]
    public void Debe_Dar_Deuce_Si_Ambos_3Puntos_E_Iguales(int scorePlayer1, int scorePlayer2)
    {
        //Act
        var score = _game.GetScore(scorePlayer1, scorePlayer2);
        //Assert
        score.Should().Be("deuce");
    }

    [Theory]
    [InlineData(4, 5, "advantage for Player2")]
    [InlineData(6, 7, "advantage for Player2")]
    [InlineData(9, 8, "advantage for Player1")]
    public void Debe_Describir_Bien_Ventaja_Si_Ambos_3_Y_1Punto_Arriba(int scorePlayer1, int scorePlayer2, string expected)
    {
        //Act
        var score = _game.GetScore(scorePlayer1, scorePlayer2);
        //Assert
        score.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, 2, "thirty-all")]
    [InlineData(0, 0, "love-all")]
    [InlineData(1, 1, "fifteen-all")]
    public void Debe_Describir_Bien_Empate_Si_Ambos_Menos_De3_Y_PuntosIguales(int scorePlayer1, int scorePlayer2, string expected)
    {
        //Act
        var score = _game.GetScore(scorePlayer1, scorePlayer2);
        //Assert
        score.Should().Be(expected);
    }
}