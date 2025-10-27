namespace Tennis;

public interface ITennisState
{
    string GetScore(int scorePlayer1, int scorePlayer2);
}

public class GameWonState : ITennisState
{
    public string GetScore(int scorePlayer1, int scorePlayer2)
    {
        return scorePlayer1 > scorePlayer2
            ? "Player1 wins the game"
            : "Player2 wins the game";
    }
}

public class AdvantageState : ITennisState
{
    public string GetScore(int scorePlayer1, int scorePlayer2)
    {
        return scorePlayer1 > scorePlayer2
            ? "advantage for Player1"
            : "advantage for Player2";
    }
}

public class DeuceState : ITennisState
{
    public string GetScore(int scorePlayer1, int scorePlayer2)
    {
        return "deuce";
    }
}

public class NormalState : ITennisState
{
    private readonly Dictionary<int, string> _scoreNames = new()
    {
        { 0, "love" },
        { 1, "fifteen" },
        { 2, "thirty" },
        { 3, "forty" }
    };

    public string GetScore(int scorePlayer1, int scorePlayer2)
    {
        return scorePlayer1 == scorePlayer2 ? $"{_scoreNames[scorePlayer1]}-all" : $"{_scoreNames[scorePlayer1]}-{_scoreNames[scorePlayer2]}";
    }
}