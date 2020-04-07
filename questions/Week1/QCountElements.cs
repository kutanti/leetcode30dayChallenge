namespace LeetCode30DayChallenge.Questions
{
    using System.Collections.Generic;
    public class QCountElements
    {
        public int CountElements(int[] arr)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (frequency.ContainsKey(arr[i]))
                {
                    frequency[arr[i]]++;
                }
                else
                {
                    frequency.Add(arr[i], 1);
                }
            }

            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (frequency.ContainsKey(arr[i] + 1) && frequency[arr[i]] > 0)
                {
                    frequency[arr[i]] -= 1;
                    count++;
                }
            }

            return count;
        }
    }
}