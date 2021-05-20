using NUnit.Framework;
using System.Linq;
using Yahtzee_Kata;

namespace Tests
{
    public class GameTests: With_an_automocked<Game>
    {

        [Test]
        public void When_scoring_it_should_return_a_score()
        {
            var scores = Enumerable.Repeat(0, 6).ToArray();
            var score = ClassUnderTest.Score(scores);
            Assert.That(score, Is.TypeOf<int>());
        } 

        [Test]
        public void When_scoring_all_ones()
        {
            var scores = Enumerable.Repeat(1, 6).ToArray();
            var score = ClassUnderTest.Score(scores);
            Assert.That(score, Is.EqualTo(6));
        }
    }
}