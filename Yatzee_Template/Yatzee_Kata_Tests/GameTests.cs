using NUnit.Framework;
using Yahtzee_Kata;

namespace Tests
{
    public class GameTests: With_an_automocked<Game>
    {

        [Test]
        public void When_scoring_it_should_return_a_score()
        {
            ClassUnderTest.Score();
            Assert.Pass();
        }
    }
}