
namespace LeetCode30DayChallenge.Questions
{
    /*
    Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
    */

    using System;
    using System.Collections.Generic;
    public class ValidParamthesis
    {
        public bool CheckValidString(string s)
        {
            int leftBalance = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] == '(') || (s[i] == '*'))
                    leftBalance++;
                else
                    leftBalance--;

                if (leftBalance < 0) return false;
            }
            if (leftBalance == 0) return true;
            int rightBalance = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if ((s[i] == ')') || (s[i] == '*'))
                    rightBalance++;
                else
                    rightBalance--;

                if (rightBalance < 0) return false;
            }
            return true;
        }

        public bool CheckValidStringUsing2Stacks(string s)
        {
            Stack<int> pair = new Stack<int>();
            Stack<int> hash = new Stack<int>();


            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    pair.Push(i);
                }
                else if (s[i] == '*')
                {
                    hash.Push(i);
                }
                else
                {
                    if (pair.Count == 0 && hash.Count == 0)
                    {
                        return false;
                    }
                    else if (pair.Count > 0)
                    {
                        pair.Pop();
                    }
                    else if (hash.Count > 0)
                    {
                        hash.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            // check the balance stacks indices
            while (pair.Count > 0)
            {
                // if there are no hash
                if (hash.Count == 0)
                {
                    return false;
                }

                // if the hash is before the first bracket.
                if (pair.Pop() > hash.Pop())
                {
                    return false;
                }
            }

            return true;
        }
    }
}