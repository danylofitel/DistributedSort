using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace DistributedSort
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedBag<int> empty = new OrderedBag<int>(new List<int>
            { });

            OrderedBag<int> a = new OrderedBag<int>(new List<int>
                    { 1, 5, 3, 7, 9, 11, 15, 13 });

            OrderedBag<int> b = new OrderedBag<int>(new List<int>
                    { 10, 4, 6, 2, 8, 12, 14, 0 });

            OrderedBag<int> c = new OrderedBag<int>(new List<int>
                    { 100, 220, -80, -40, 60});

            OrderedBag<int> d = new OrderedBag<int>(new List<int>
                    { 121, 64, 81, -144, 16, 25, 49, -36 });

            Random generator = new Random();
            OrderedBag<int> random = new OrderedBag<int>(
                Enumerable.Range(0, 20).Select(x => generator.Next() % 1000));

            List<OrderedBag<int>> remotes = new List<OrderedBag<int>> { empty, a, b, c, d, random };

            foreach (var elem in DistributedHeapSort<int>.Sort(remotes))
            {
                Console.Write($"{elem}, ");
            }

            Console.WriteLine();
        }
    }
}
