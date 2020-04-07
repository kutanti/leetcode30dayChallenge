namespace LeetCode30DayChallenge.Questions
{
    public class QMoveZeroes
    {
        // Time O(n)
        // Space O(1)
        // Question Link: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3286/
        public static void MoveZeroes(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return;
            }

            int temp = 0;
            int nonZeroIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    temp = nums[i];
                    nums[i] = 0;
                    nums[nonZeroIndex] = temp;
                    nonZeroIndex++;
                }
            }
        }
    }
}