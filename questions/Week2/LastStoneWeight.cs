namespace LeetCode30DayChallenge.Questions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LastStoneWeightSoln
    {
        public int LastStoneWeight(int[] stones)
        {
            var sorted = new SortedDictionary<int, int>();

            // put all numbers into minimum heap - default - negative value
            foreach (var number in stones)
            {
                var key = number * (-1);
                if (!sorted.ContainsKey(key))
                {
                    sorted.Add(key, 0);
                }
                sorted[key]++;
            }

            while (!((sorted.Keys.Count == 1 && sorted[sorted.Keys.ToList()[0]] == 1) || sorted.Keys.Count == 0))
            {
                // get minimum two values from minimum heap
                var key = sorted.Keys.First();
                var hasAtLeastTwo = sorted[key] > 1;
                if (hasAtLeastTwo)
                {
                    sorted[key] -= 2;
                    if (sorted[key] == 0)
                    {
                        sorted.Remove(key);
                    }
                }
                else
                {
                    var minimum = key;
                    sorted.Remove(key);
                    var next = sorted.Keys.First();
                    sorted[next]--;

                    if (sorted[next] == 0)
                    {
                        sorted.Remove(next);
                    }

                    var diff = Math.Abs(minimum - next);
                    var newKey = diff * (-1);

                    if (newKey == 0)
                        continue;

                    if (!sorted.ContainsKey(newKey))
                    {
                        sorted.Add(newKey, 0);
                    }

                    sorted[newKey]++;
                }
            }

            if (sorted.Keys.Count == 0)
                return 0;

            return sorted.Keys.ToList()[0] * (-1);
        }
    }
}