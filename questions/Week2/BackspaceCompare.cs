namespace LeetCode30DayChallenge.Questions
{
    using System.Collections.Generic;
    public class SolutionBackspaceCompare
    {
        /*
        Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.
        */
        public static bool BackspaceCompare(string S, string T)
        {

            int m = 0;
            Queue<char> q = new Queue<char>();
            for (int i = S.Length - 1; i >= 0; i--)
            {
                if (S[i] == '#')
                {
                    m++;
                }
                else if (m > 0)
                {
                    m--;
                }
                else
                {
                    q.Enqueue(S[i]);
                }
            }

            int n = 0;
            for (int i = T.Length - 1; i >= 0; i--)
            {
                if (T[i] == '#')
                {
                    n++;
                }
                else if (n > 0)
                {
                    n--;
                }
                else
                {
                    if (!q.Dequeue().Equals(T[i]))
                    {
                        return false;
                    }
                }
            }

            return q.Count == 0 ? true : false;
        }
    }
}