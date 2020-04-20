namespace LeetCode30DayChallenge.Questions
{
public class RotatedArraySearch
{
    public int Search(int[] nums, int target) 
    {
        if (nums == null || nums.Length == 0) return -1;

        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            int mid = (right + left) / 2;
            if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        int start = left;
        left = 0;
        right = nums.Length - 1;
        // 4, 5, 6, 7, 8, 9, 24, 17, 0, 1, 2
        if (nums[start] <= target && nums[right] >= target)
        {
            left = start;
        }
        else
        {
            right = start;
        }

        while (left <= right)
        {
            int mid = (right + left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return -1;
    }
} 
}