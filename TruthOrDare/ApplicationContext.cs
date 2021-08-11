using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDare
{
    static class ApplicationContext
    {
        public static List<Player> PlayerList { get; set; }

        public static bool ShuffleChecked { get; set; } = false;

        public static bool RandomChecked { get; set; } = false;

        public static string YouName { get; set; } = "You";

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
