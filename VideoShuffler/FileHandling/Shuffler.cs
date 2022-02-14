using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoShuffler.FileHandling
{
    public class Shuffler<T>
    {
        public static IEnumerable<T> ShuffleAndGet(T[] list, int qty)
        {
            Random rng = new Random();

            int n = list.Length;
            while (n-- > 1)
            {
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            List<T> li = new List<T>();
            n = list.Length;

            for (int i = 0; i < qty; i++)
            {
                int k = rng.Next(n-- + 1);
                li.Add(list[k]);
            }

            return li;
        }
    }
}