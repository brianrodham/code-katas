using BowlingScoring;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [TestCase(0, 0)]
        [TestCase(1, 20)]
        [TestCase(2, 40)]
        [TestCase(3, 60)]
        [TestCase(4, 80)]
        public void When_all_rolls_are_the_same_no_extra_frames(int roll, int score)
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(Enumerable.Repeat(roll, 20).ToArray()) == score);
        }

        [Test]
        public void When_rolling_a_single_spare()
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(new[] { 9, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }) == 10);
        }

        [Test]
        public void When_rolling_a_single_spare_and_score()
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(new[] { 9, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }) == 12);
        }

        [Test]
        public void When_rolling_a_single_strike()
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(new[] { 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }) == 10);
        }

        [Test]
        public void When_rolling_a_single_strike_and_single_score()
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(new[] { 10, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }) == 12);
        }

        [Test]
        public void When_rolling_a_single_strike_and_score_full_frame()
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(new[] { 10, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }) == 14);
        }

        [Test]
        public void When_all_rolls_are_spares()
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(Enumerable.Repeat(5, 21).ToArray()) == 150);
        }

        [Test]
        public void When_all_rolls_are_strikes()
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(Enumerable.Repeat(10, 12).ToArray()) == 300);
        }

        [Test]
        public void Random_Game_Scores()
        {
            BowlingGame game = new BowlingGame();
            Assert.That(game.Score(new[] { 10, 7, 2, 3, 4, 1, 1, 3, 6, 10, 8, 1, 10, 10, 9, 1, 10 }) == 143);
        }
    }
}