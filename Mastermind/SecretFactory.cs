using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mastermind_game
{
    class SecretFactory
    {
        private List<string> colors = new List<string>(new string[] { "Red", "Blue", "Yellow", "Green", "Orange", "Purple" });

        public List<string> GenerateSecret()
        {
            Random rnd = new Random();
            var newSecret = colors.OrderBy(x => rnd.Next()).Take(4).ToList();
            return newSecret.Select(x => x.ToLower()).ToList();
        }

    }
}
