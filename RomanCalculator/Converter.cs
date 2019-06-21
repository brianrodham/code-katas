using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanCalculator
{

    struct RomanNumeral
    {
        public string roman;
        public int numeric;
    }
    class Converter
    {
        private List<RomanNumeral> romanNumerals = new List<RomanNumeral>();

        public Converter()
        {
            romanNumerals = PopulateNumeralList();
        }

        private List<RomanNumeral> PopulateNumeralList()
        {
            return new List<RomanNumeral>
            {
                new RomanNumeral {
                    roman="M",
                    numeric=1000
                },
                new RomanNumeral {
                    roman="CM",
                    numeric=900
                },
                new RomanNumeral {
                    roman="D",
                    numeric=500
                },
                new RomanNumeral {
                    roman="CD",
                    numeric=400
                },
                new RomanNumeral {
                    roman="C",
                    numeric=100
                },
                new RomanNumeral {
                    roman="LC",
                    numeric=90
                },
                new RomanNumeral {
                    roman="L",
                    numeric=50
                },
                new RomanNumeral {
                    roman="LX",
                    numeric=40
                },
                new RomanNumeral {
                    roman="X",
                    numeric=10
                },
                new RomanNumeral {
                    roman="IX",
                    numeric=9
                },
                new RomanNumeral {
                    roman="V",
                    numeric=5
                },
                new RomanNumeral {
                    roman="IV",
                    numeric=4
                },
                new RomanNumeral {
                    roman="I",
                    numeric=1
                }
            };          
        }

        public int ConvertToNumeric(string roman)
        {
            int total = 0;
            string[] characters = roman.Select(x => new string(x, 1)).ToArray();
            for (int i = 0; i < characters.Count(); i++)
            {
                string character = characters.ElementAtOrDefault(i);
                string nextCharacter = characters.ElementAtOrDefault(i + 1);
                int characterValue = ConvertRomanCharacter(character);
                int nextCharacterValue = ConvertRomanCharacter(nextCharacter);

                if (characterValue > nextCharacterValue)
                {
                    total += characterValue;
                }
                else
                {
                    i++;
                    character += nextCharacter;
                    total += ConvertRomanCharacter(character);
                }
            }
            return total;
        }

        public string ConvertToRoman(int numeric)
        {
            string roman = "";
            foreach(RomanNumeral romanNumeral in romanNumerals)
            {
                int symbolCount = numeric / romanNumeral.numeric;
                numeric = numeric % romanNumeral.numeric;
                roman += string.Concat(Enumerable.Repeat(romanNumeral.roman, symbolCount));
            }
            return roman;
        }

        public int ConvertRomanCharacter(string character)
        {
            return romanNumerals.Where(x => x.roman == character).Select(x => x.numeric).FirstOrDefault();
        }
    }
}
