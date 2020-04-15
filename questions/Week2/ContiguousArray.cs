namespace LeetCode30DayChallenge.Questions
{
    using System;
    using System.Collections.Generic;
    public class ContiguousArraySolution1
    {

        // Time limit exceeded.
        public int FindMaxLength(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            return GetCount(nums, 0, nums.Length - 1);
        }

        private static int GetCount(int[] nums, int start, int end)
        {
            int zero = 0;
            int one = 0;
            for (int i = start; i <= end; i++)
            {
                if (nums[i] == 0)
                {
                    zero++;
                }
                else
                {
                    one++;
                }
            }

            if (zero == one)
            {
                return end - start + 1;
            }
            return Math.Max(GetCount(nums, start + 1, end), GetCount(nums, start, end - 1));
        }

        public int FindMaxLengthOptimized(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            // Accepted.

            int value = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    value -= 1;
                }
                else
                {
                    value += 1;
                }
                nums[i] = value;
            }


            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(0, 0);
            int maxlen = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    maxlen = Math.Max(maxlen, i - dict[nums[i]] + 1);
                }
                else
                {
                    dict.Add(nums[i], i + 1);
                }
            }

            return maxlen;
        }
    }
}