namespace LeetCode30DayChallenge.Questions
{
    /*
    Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
    */
    public class ArrayProduct
    {
        // Time O(n) + O(n) ~ O(n)
        // Space O(n)// space can be reduced by elimination the right array and keeping the product in a variable.
        public int[] ProductExceptSelf(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return new int[0];
            }

            int[] leftProducts = new int[nums.Length];
            int[] rightProducts = new int[nums.Length];

            int lp = 1, rp = 1;
            for (int i = 0, j = nums.Length - 1; i < nums.Length && j >= 0; i++, j--)
            {
                leftProducts[i] = lp;
                lp = lp * nums[i];

                rightProducts[j] = rp;
                rp = rp * nums[j];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = leftProducts[i] * rightProducts[i];
            }

            return nums;
        }
    }

}