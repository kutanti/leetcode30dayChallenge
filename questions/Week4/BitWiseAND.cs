namespace LeetCode30DayChallenge.Questions
{
    public class BitWiseANDoFRange
    {
        // Time - O(1)
        // Space is max 32 bit, we can consider it as O(1).
        public int RangeBitwiseAnd(int m, int n)
        {

            // keep a counter
            int count = 0;

            // iterate till m is equal to n, so that we get fixed number of bits which are common in m & n.
            while (m != n)
            {
                // right shift m & n so that m is equal to n
                // right shift will remove one bit from the right.
                // if the bit from the right is not equal then we are sure it is flipped, hence bitwise & is 0.    
                m = m >> 1;
                n = n >> 1;
                // increment counter to keep track how many bits are removed.
                count++;
            }
            // left shift m with count, so the number of removed bits is replaced with zero.
            // this is the answer.
            return m << count;
        }
    }
}