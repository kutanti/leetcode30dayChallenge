namespace LeetCode30DayChallenge.Questions
{
    using System;
    using System.Collections.Generic;
    public class MinPathSumSoln
    {
        public int MinPathSum(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0) return 0;

            int rows = grid.Length;
            int cols = grid[0].Length;

            int[] dp = new int[cols];
            dp[0] = grid[0][0];

            for (int i = 1; i < cols; i++)
                dp[i] = dp[i - 1] + grid[0][i];

            for (int i = 1; i < rows; i++)
            {
                dp[0] = grid[i][0] + dp[0];
                for (int j = 1; j < cols; j++)
                {
                    dp[j] = grid[i][j] + Math.Min(dp[j], dp[j - 1]);
                }
            }

            return dp[cols - 1];
        }

    }
}