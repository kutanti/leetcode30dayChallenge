namespace LeetCode30DayChallenge
{
    using System;
    using LeetCode30DayChallenge.Questions;
    public class Program
    {
        public static void Main(string[] args)
        {

            var res = MaximumSubArray.MaxSubArray(new int[] { 1, 1, 3, 4, -14, -6, 1 });
            Console.WriteLine("answer:" + res);

        }
    }
}