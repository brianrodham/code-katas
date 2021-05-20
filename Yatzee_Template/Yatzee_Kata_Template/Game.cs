using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee_Kata
{
    public class Game
    {
        public Game() { }
        public int Score(int[] scores)
        {
            return scores.Sum();
        }
    }
}
