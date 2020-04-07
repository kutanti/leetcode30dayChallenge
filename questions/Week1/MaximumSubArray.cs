namespace LeetCode30DayChallenge.Questions
{
    public class MaximumSubArray
    {
        // Time O(n)
        // Space O(1)
        // Question Link: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3285/
        public static int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int max_current = 0;
            int max_so_far = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                max_current = max_current + nums[i];

                if (max_so_far < max_current)
                    max_so_far = max_current;

                if (max_current < 0)
                    max_current = 0;
            }
            return max_so_far;
        }
    }
}