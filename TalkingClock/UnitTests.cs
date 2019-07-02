using NUnit.Framework;

namespace TalkingClock
{
    public class Tests
    {
        [Test]
        public void Returns_string_in_right_format()
        {
            Clock clock = new Clock();
            string time = clock.Talk("12:00");
            Assert.That(time.Contains("It is "));
            Assert.That(time.Contains("PM") || time.Contains("AM"));
        }
        [Test]
        public void Returns_time_with_AM()
        {
            Clock clock = new Clock();
            string time = clock.Talk("10:22");
            Assert.That(time.Contains("AM"));
        }

        [Test]
        public void Returns_time_with_PM()
        {
            Clock clock = new Clock();
            string time = clock.Talk("22:22");
            Assert.That(time.Contains("PM"));
        }
        
        [Test]
        public void Calculate_hours_am()
        {
            Clock clock = new Clock();
            string time = clock.Talk("10:00");
            Assert.That(time.Contains("ten"));
            Assert.That(time.Contains("AM"));
        }

        [Test]
        public void Calculate_hours_pm()
        {
            Clock clock = new Clock();
            string time = clock.Talk("22:22");
            Assert.That(time.Contains("ten"));
            Assert.That(time.Contains("PM"));
        }

        [Test]
        public void Calculate_time_am_no_minutes()
        {
            Clock clock = new Clock();
            string time = clock.Talk("10:00");
            Assert.That(time, Is.EqualTo("It is ten AM"));          
        }

        [Test]
        public void Calculate_time_pm_no_minutes()
        {
            Clock clock = new Clock();
            string time = clock.Talk("22:00");
            Assert.That(time, Is.EqualTo("It is ten PM"));
        }

        [Test]
        public void Calculate_time_with_under_ten_minutes()
        {
            Clock clock = new Clock();
            string time = clock.Talk("13:08");
            Assert.That(time, Is.EqualTo("It is one oh eight PM"));
        }

        [TestCase("00:00", "It is twelve AM")]
        [TestCase("01:30", "It is one thirty AM")]
        [TestCase("12:05", "It is twelve oh five PM")]
        [TestCase("14:01", "It is two oh one PM")]
        [TestCase("20:29", "It is eight twenty nine PM")]
        [TestCase("21:00", "It is nine PM")]
        public void Provided_sample_tests(string timeDigits, string timeText)
        {
            Clock clock = new Clock();
            string time = clock.Talk(timeDigits);
            Assert.That(time, Is.EqualTo(timeText));
        }

    }
}