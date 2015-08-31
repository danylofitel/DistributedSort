using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace DistributedSort
{
    public static class DistributedHeapSort<T> where T : IComparable<T>
    {
        public static IEnumerable<T> Sort(IEnumerable<OrderedBag<T>> remotes)
        {
            OrderedBag<Tuple<T, OrderedBag<T>>> buffer =
                new OrderedBag<Tuple<T, OrderedBag<T>>>((a, b) => a.Item1.CompareTo(b.Item1));

            // Initialize heap.
            foreach (var remote in remotes)
            {
                if (remote.Count > 0)
                {
                    T elem = remote.RemoveFirst();
                    buffer.Add(new Tuple<T, OrderedBag<T>>(elem, remote));
                }
            }

            // Retrieve min element step by step.
            while (buffer.Count > 0)
            {
                Tuple<T, OrderedBag<T>> nextMin = buffer.RemoveFirst();
                yield return nextMin.Item1;

                if (nextMin.Item2.Count > 0)
                {
                    buffer.Add(new Tuple<T, OrderedBag<T>>(
                        nextMin.Item2.RemoveFirst(), nextMin.Item2));
                }
            }
        }
    }
}
