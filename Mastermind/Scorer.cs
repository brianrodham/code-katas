using System;
using System.Collections.Generic;
using System.Linq;

namespace mastermind_game
{
    class Scorer
    {
        public GuessResult Score(List<string> guess, List<string> secret)
        {
            var result = new GuessResult();
            var remainingSecret = new List<string>();
            var remainingGuess = new List<string>();

            for (var i = 0; i < guess.Count(); i++)
            {
                if (guess[i] == secret[i])
                {
                    result.Correct++;
                }
                else
                {
                    remainingSecret.Add(secret[i]);
                    remainingGuess.Add(guess[i]);
                }
            }

            for (var i = 0; i < remainingGuess.Count(); i++)
            {
                var index = remainingSecret.IndexOf(remainingGuess[i]);
                if (index >= 0)
                {
                    result.Misplaced++;
                    remainingSecret[index] = "";
                }
            }

            return result;
        }
    }
}
