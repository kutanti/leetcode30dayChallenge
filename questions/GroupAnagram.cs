namespace LeetCode30DayChallenge.Questions
{
    using System.Collections.Generic;
    using System;
    public class Solution
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] ar = strs[i].ToCharArray();
                Array.Sort(ar);
                string key = string.Join("", ar);

                if (dict.ContainsKey(key))
                {
                    dict[key].Add(strs[i]);
                }
                else
                {
                    dict.Add(key, new List<string>() { strs[i] });
                }
            }

            IList<IList<string>> res = new List<IList<string>>();
            foreach (var item in dict)
            {
                res.Add(item.Value);
            }

            return res;

        }
    }
}