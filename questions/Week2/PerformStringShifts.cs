namespace LeetCode30DayChallenge.Questions
{
    using System;
    public class PerformStringShifts
    {
        public string StringShift(string s, int[][] shift)
        {
            if (s == null || s.Length == 0)
            {
                return string.Empty;
            }
            else if (shift == null || shift.Length == 0)
            {
                return s;
            }


            for (int i = 0; i < shift.Length; i++)
            {
                if (shift[i][0] == 1)
                {
                    //right shift
                    int r = 0;
                    while (r < shift[i][1])
                    {
                        s = RightShift(s);
                        r++;
                    }
                }
                else if (shift[i][0] == 0)
                {
                    //left  shift

                    int r = 0;
                    while (r < shift[i][1])
                    {
                        s = LeftShift(s);
                        r++;
                    }

                }
                else
                {
                    throw new InvalidOperationException("Shift operation is not valid.");
                }
            }
            return s;
        }

        private string RightShift(string s)
        {
            char[] sArr = new char[s.Length];
            char prev = s[s.Length - 1];
            for (int i = 0; i < s.Length; i++)
            {
                char curr = s[i];
                sArr[i] = prev;
                prev = curr;
            }

            return new string(sArr);

        }
        private string LeftShift(string s)
        {
            char[] sArr = new char[s.Length];
            char prev = s[0];
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char curr = s[i];
                sArr[i] = prev;
                prev = curr;
            }

            return new string(sArr);

        }
    }
}