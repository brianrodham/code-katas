using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingClock
{
    class Clock
    {
        public string Talk(string time)
        {
            string[] parts = time.Split(":");
            int hour = Convert.ToInt32(parts.GetValue(0));
            int minutes = Convert.ToInt32(parts.GetValue(1));
            bool afterNoon = (hour > 11) ? true : false;
            hour = (hour == 12 || hour == 0) ? 12 : hour % 12;

            string hourString = Translator.Translate(hour);
            string minuteString = Translator.Translate(minutes);

            string timeString = "It is " + hourString + " ";
            timeString += (minutes < 10 && minutes > 0) ? "oh " : "";
            timeString += (minuteString != "") ? minuteString + " " : "";
            timeString += (afterNoon ? "PM" : "AM");

            return timeString; 


        }
    }
}
