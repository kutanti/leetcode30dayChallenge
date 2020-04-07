namespace LeetCode30DayChallenge.Questions
{
    using System.Collections.Generic;
    public class QSingleNumber
    {
        // Time - O(n)
        // Space - O(n)
        // Question Link: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3283/
        public static int SingleNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            Dictionary<int, int> frequency = new Dictionary<int, int>();
            int value = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (frequency.ContainsKey(nums[i]))
                {
                    frequency[nums[i]]++;
                }
                else
                {
                    frequency.Add(nums[i], 1);
                }

            }
            foreach (var item in frequency)
            {
                if (item.Value == 1)
                {
                    value = item.Key;
                    break;
                }
            }
            return value;
        }
    }
}