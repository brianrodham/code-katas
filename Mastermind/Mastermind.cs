using System.Collections.Generic;

namespace mastermind_game
{
    public enum GameState
    {
        NotStarted,
        InProgress,
        GameOver,
        Victory
    }

    public class Mastermind
    {

        private Scorer guesser = new Scorer();
        private SecretFactory secretFactory = new SecretFactory();
        private int guessCount = 0;
        private GameState state = GameState.NotStarted;

        const int MAX_GUESSES = 10;
        private List<string> secret { get; set; }

        public void StartGame(List<string> presetSecret = null)
        {
            state = GameState.InProgress;
            guessCount = 0;
            secret = presetSecret ?? secretFactory.GenerateSecret();
        }

        public GameState Guess(List<string> guess)
        {
            if (GameIsInActive())
            {
                return state;
            }

            GuessResult result = guesser.Score(guess, secret);
            guessCount++;

            if (IsWinningState(result))
            {
                state = GameState.Victory;
                return state;
            }
            if(IsLosingState(result))
            {
                state = GameState.GameOver;
                return state;
            }
            return GameState.InProgress;
        }

        private bool GameIsInActive()
        {
            return state == GameState.NotStarted || state == GameState.GameOver || state == GameState.Victory;
        }

        private bool IsWinningState(GuessResult result)
        {
            return result.Correct == 4 && result.Misplaced == 0;
        }

        private bool IsLosingState(GuessResult result)
        {
            return result.Correct < 4 && guessCount >= MAX_GUESSES;
        }

    }

    public class GuessResult
    {
        public int Correct { get; set; } = 0;
        public int Misplaced { get; set; } = 0;
    }
}