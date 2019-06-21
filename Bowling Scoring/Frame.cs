using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScoring
{
    class Frame
    {
        List<int> rolls = new List<int>();

        public int GetBall(int index)
        {
            return rolls[index-1];
        }
        public int Sum()
        {
            int sum = rolls.Sum();
            if(sum > 10)
            {
                sum = 10;
            }
            return sum;
        }

        public bool IsSpare()
        {
            return (Sum() == 10);
        }

        public bool IsStrike()
        {
            return (GetBall(1) == 10);
        }

        public void Add(int roll)
        {
            rolls.Add(roll);
        }

        public bool IsComplete()
        {
            return ( rolls.Count() == 2 || rolls.Sum() >= 10);
        }

        public int SpareBonus()
        {
            return rolls[0];
        }

        public int StrikeBonus()
        {
            return rolls[0] + rolls[1];
        }
    }
}
