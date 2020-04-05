namespace LeetCode30DayChallenge.Questions
{
    public class BestTimeToBuySellStock
    {
        // Time O(n)
        // Space O(1)
        // Question Link: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3287/
        public static int MaxProfit(int[] prices)
        {
            // since there can be any number of transaction so just preserve the profit when there is any.
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }

            return maxProfit;
        }
    }
}