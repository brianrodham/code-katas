using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanCalculator
{
    public class UnitTests
    {
        [Test]
        public void Calculator_returns_string_value()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("XIV", "XV");
            Assert.That(value, Is.TypeOf<string>());
        }

        [Test]
        public void Can_add_one_plus_one()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("I", "I");
            Assert.That(value, Is.EqualTo("II"));             
        }

        [Test]
        public void Can_add_five()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("V", "V");
            Assert.That(value, Is.EqualTo("X"));
        }

        [Test]
        public void Can_add_ten()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("X", "X");
            Assert.That(value, Is.EqualTo("XX"));
        }

        [Test]
        public void Can_add_fifty()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("L", "L");
            Assert.That(value, Is.EqualTo("C"));
        }

        [Test]
        public void Can_add_one_hundred()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("C", "C");
            Assert.That(value, Is.EqualTo("CC"));
        }

        [Test]
        public void Can_add_five_hundred()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("D", "D");
            Assert.That(value, Is.EqualTo("M"));
        }

        [Test]
        public void Can_add_one_thousand()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("M", "M");
            Assert.That(value, Is.EqualTo("MM"));
        }

        [Test]
        public void Can_add_four()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("IV", "IV");
            Assert.That(value, Is.EqualTo("VIII"));
        }
        [Test]
        public void Can_calculate_complicated()
        {
            Calculator calculator = new Calculator();
            string value = calculator.Add("XIV", "LX");
            Assert.That(value, Is.EqualTo("LXXIV"));

        }

        [Test]
        public void Can_convert_numeric_to_roman()
        {
            Converter converter = new Converter();
            string value = converter.ConvertToRoman(14);
            Assert.That(value, Is.EqualTo("XIV"));
        }

        [Test]
        public void Can_convert_roman_to_numeric()
        {
            Converter converter = new Converter();
            int value = converter.ConvertToNumeric("XIV");
            Assert.That(value, Is.EqualTo(14));
        }
    }
}
