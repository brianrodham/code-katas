using System.Linq;

namespace RomanCalculator
{
    public class Calculator { 


        private Converter converter = new Converter();

        public string Add(string num1, string num2)
        {
            int score = converter.ConvertToNumeric(num1) + converter.ConvertToNumeric(num2);
            return converter.ConvertToRoman(score);          
        }

    }
}
