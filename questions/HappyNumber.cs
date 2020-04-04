namespace LeetCode30DayChallenge.Questions
{
    using System.Collections.Generic;
    using System;
    public class HappyNumber
    {
        // Time varries from number to number.
        // Space varries from number to number.
        public static bool IsHappy(int n)
        {
            int prevSum = digitsquaresum(n);
            HashSet<int> sums = new HashSet<int>();

            while (prevSum != 1)
            {
                int curSum = digitsquaresum(prevSum);
                if (sums.Contains(curSum))
                {
                    return false;
                }
                else
                {
                    sums.Add(curSum);
                }

                prevSum = curSum;
            }

            return true;
        }

        public static int digitsquaresum(int n)
        {
            int sum = 0;
            do
            {
                sum += (int)Math.Pow(n % 10, 2);
                n /= 10;
            } while (n != 0);

            return sum;
        }
    }
}