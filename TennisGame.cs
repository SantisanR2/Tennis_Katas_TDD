namespace Tennis;

public class TennisGame
{
    public string GetScore(int scorePlayer1, int scorePlayer2)
    {
        ITennisState state = DetermineState(scorePlayer1, scorePlayer2);
        return state.GetScore(scorePlayer1, scorePlayer2);
    }

    private ITennisState DetermineState(int scorePlayer1, int scorePlayer2)
    {
        if ((scorePlayer1 >= 4 || scorePlayer2 >= 4) &&
            Math.Abs(scorePlayer1 - scorePlayer2) >= 2)
        {
            return new GameWonState();
        }

        if (scorePlayer1 >= 3 && scorePlayer2 >= 3 &&
            Math.Abs(scorePlayer1 - scorePlayer2) == 1)
        {
            return new AdvantageState();
        }

        if (scorePlayer1 >= 3 && scorePlayer2 >= 3 &&
            scorePlayer1 == scorePlayer2)
        {
            return new DeuceState();
        }

        return new NormalState();
    }
}