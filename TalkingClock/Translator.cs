using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingClock
{
    static class Translator
    {
        public static string Translate(int time)
        {
            if(time == 1)
            {
                return "one";
            }
            if(time == 2)
            {
                return "two";
            }
            if(time == 3)
            {
                return "three";
            }
            if(time == 4)
            {
                return "four";
            }
            if(time == 5)
            {
                return "five";
            }
            if(time == 6)
            {
                return "six";
            }
            if(time== 7)
            {
                return "seven";
            }
            if(time == 8)
            {
                return "eight";
            }
            if(time == 9)
            {
                return "nine";
            }
            if(time == 10)
            {
                return "ten";
            }
            if (time == 11)
            {
                return "eleven";
            }
            if(time == 12)
            {
                return "twelve";
            }
            if(time == 13)
            {
                return "thirteen";
            }
            if(time == 14)
            {
                return "fourteen";
            }
            if(time == 15)
            {
                return "fifteen";
            }
            if(time == 16)
            {
                return "sixteen";
            }
            if(time == 17)
            {
                return "seventeen";
            }
            if(time == 18)
            {
                return "eighteen";
            }
            if(time == 19)
            {
                return "nineteen";
            }
            if ( time == 20)
            {
                return "twenty";
            }
            if (time > 20 && time < 30) {
                return "twenty " + Translate(time - 20);
            }
            if(time == 30)
            {
                return "thirty";
            }
            if (time > 30 && time < 40)
            {
                return "twenty " + Translate(time - 30);
            }
            if(time == 40)
            {
                return "fourty";
            }
            if (time > 40 && time < 50)
            {
                return "fourty " + Translate(time - 40);
            }
            if(time == 50)
            {
                return "fifty";
            }
            if(time > 50 && time < 60)
            {
                return "fifty " + Translate(time - 50);
            }
            
            return "";
        }

    }
}
