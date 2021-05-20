using NUnit.Framework;
using System.Linq;

namespace mastermind_game
{
    public class GuesserTests
    {
        [Test]
        [TestCase("red,green,green,purple", "red,blue,yellow,green", 1, 1)]
        [TestCase("red,green,green,purple", "black,blue,yellow,green", 0, 1)]
        [TestCase("red,green,green,purple", "black,green,yellow,purple", 2, 0)]
        [TestCase("red,red,red,red", "red,green,red,red", 3, 0)]
        [TestCase("red,green,green,purple", "red,red,green,purple", 3, 0)]
        [TestCase("red,green,green,purple", "red,green,green,green", 3, 0)]
        [TestCase("red,green,green,purple", "red,green,purple,green", 2, 2)]
        [TestCase("red,green,yellow,purple", "green,blue,blue,green", 0, 1)]
        [TestCase("red,green,green,purple", "red,blue,yellow,red", 1,0)]
        public void ItShouldScoreProperly(string secret, string guess, int expectedCorrect, int expectedMisplaced)
        {
            var scorer = new Scorer();
            var secretList = secret.Split(',').ToList();
            var guessList = guess.Split(',').ToList();

            var result = scorer.Score(guessList, secretList);

            Assert.That(result.Correct, Is.EqualTo(expectedCorrect), "Expected number of correct was wrong");
            Assert.That(result.Misplaced, Is.EqualTo(expectedMisplaced), "Misplaced was wrong");
            Assert.That(result.Correct + result.Misplaced, Is.LessThanOrEqualTo(4));
        }
    }

    public class MasterMindTests
    {

        [Test]
        [TestCase("", "red,green,green,purple", GameState.NotStarted, 1, Description = "Test what happens when no secret is set")]
        [TestCase("red,green,green,purple", "red,green,green,purple", GameState.Victory, 1, Description = "Test simple victory case")]
        [TestCase("red,green,green,purple", "red,green,green,purple", GameState.Victory, 11, Description = "Test that victory is returned when calling function an arbitrary number of times")]
        [TestCase("red,green,green,purple", "green,green,green,green", GameState.GameOver, 10, Description = "Test that it sets state to game over after 10th guess")]
        [TestCase("red,green,green,purple", "green,green,green,green", GameState.GameOver, 11, Description = "Test that it sets state to game over on > 10 guesses")]
        [TestCase("red,green,green,purple", "green,green,green,green", GameState.InProgress, 1, Description = "Test that state is set to in progress after first incorrect guess")]
        [TestCase("red,green,green,purple", "green,green,green,green", GameState.InProgress, 9, Description = "Test that state is set to in progress after 9th incorrect guess")]
        public void TestGameStateAfterGuessing(string secretString, string guessString, GameState state, int loopCount)
        {

            var secret = secretString.Split(',').ToList();
            var guess = guessString.Split(',').ToList();

            var mastermind = new Mastermind();
            if (secretString != "")
            {
                mastermind.SetSecret(secret);
            }
            var result = GameState.InProgress;
            for (int i = 0; i < loopCount; i++)
            {
                result = mastermind.Guess(guess);
            }
            Assert.That(result, Is.EqualTo(state));
        }
    }

}
