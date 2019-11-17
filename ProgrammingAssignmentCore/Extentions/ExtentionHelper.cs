using System;
using System.Collections.Generic;

namespace ProgrammingAssignmentCore
{
    public static class ExtentionHelper
    {

        public static bool IsPrime(this int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var upperBound = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= upperBound; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
        {
            var items = new List<T>();
            foreach (var item in source)
            {
                items.Add(item);
                if (items.Count == size)
                {
                    yield return items;
                    items = new List<T>();
                }
            }

            if (items.Count != 0)
            {
                yield return items;
            }
        }

    }
}
