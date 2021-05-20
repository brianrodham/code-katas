using NUnit.Framework;

namespace HexColor
{
    public class Tests
    { 
        [TestCase(0, 0, 0, "#000000", Description = "Convert_all_zeros_to_black")]
        [TestCase(255, 255, 255, "#FFFFFF", Description = "Convert_all_255_to_white")]
        [TestCase(255, 99, 71, "#FF6347")]
        [TestCase(184, 134, 11, "#B8860B")]
        [TestCase(189, 183, 107, "#BDB76B")]
        [TestCase(0, 0, 205, "#0000CD")]
        public void Test_given_examples(int red, int green, int blue, string answer)
        {
            Converter converter = new Converter();
            string hex = converter.ColorToHex(red, green, blue);
            Assert.That(hex, Is.EqualTo(answer));
        }
    }
}