using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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
        const int MAX_GUESSES = 10;

        private int guessCount = 0;
        private List<string> secret = new List<string>();
        private GameState state = GameState.NotStarted;

        public void SetSecret(List<string> newSecret)
        {
            state = GameState.InProgress;
            guessCount = 0;
            secret = newSecret.Select(x => x.ToLower()).ToList();
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