namespace LeetCode30DayChallenge.Questions
{
    using System.Collections.Generic;
    public class SolutionBackspaceCompare
    {
        /*
        Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.
        */

        // Brute Force.
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


        // Optimized.
        public static bool BackspaceCompareOptimized(string S, string T)
        {
            // Time : O(n)
            // Space : O(1)

            //find the last character of each strings.
            // compare both
            // if true proceed, else return false.
            int lastS = S.Length - 1;
            int lastT = T.Length - 1;


            int hash = 0;
            while (lastS >= 0 || lastT >= 0)
            {

                while (lastS >= 0)
                {
                    if (S[lastS] == '#')
                    {
                        hash++;
                        lastS--;
                    }
                    else if (hash > 0)
                    {
                        hash--;
                        lastS--;
                    }
                    else
                    {
                        break;
                    }
                }

                hash = 0;
                while (lastT >= 0)
                {
                    if (T[lastT] == '#')
                    {
                        hash++;
                        lastT--;
                    }
                    else if (hash > 0)
                    {
                        hash--;
                        lastT--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (lastS == -1 && lastT == -1)
                {
                    // if both become empty.
                    return true;
                }
                else if (lastS == -1 || lastT == -1)
                {
                    // if one become empty.
                    return false;
                }
                // compare character of both string from the end.
                if (S[lastS] != T[lastT])
                {
                    return false;
                }
                lastS--;
                lastT--;
            }

            return true;

        }
    }
}