namespace LeetCode30DayChallenge.Questions
{

    using System;
    using System.Collections.Generic;
    /**
 * // This is BinaryMatrix's API interface.
 * // You should not implement it, or speculate about its implementation
 * class BinaryMatrix {
 *     public int Get(int x, int y) {}
 *     public IList<int> Dimensions() {}
 * }
 */

    // This is not implemented, just for using the methods.
    class BinaryMatrix
    {
        public int Get(int x, int y) { return 0; }
        public IList<int> Dimensions() { return null; }
    }




    // Using B-Tree search , Not Accepted (You made too many calls to BinaryMatrix.get().)
    class LeftMostColumnWithOneSoln
    {

        // Accepted.
        public int LeftMostColumnWithOneAccepted(BinaryMatrix binaryMatrix)
        {
            // Time - Worst Case O(n*m)
            // Space - O(1)

            int rows = binaryMatrix.Dimensions()[0];
            int cols = binaryMatrix.Dimensions()[1];
            int row = 0;
            int col = cols - 1;

            int result = -1;
            while (row < rows && col >= 0)
            {
                // check from end of first row, and move left if 1, move down if 0.
                if (binaryMatrix.Get(row, col) == 1)
                {
                    result = col;
                    col--;
                }
                else
                {
                    row++;
                }
            }

            return result;
        }

        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            // Time - O(n*log(m))
            // Space - O(1)
            int l1 = binaryMatrix.Dimensions()[0];
            int l2 = binaryMatrix.Dimensions()[1] - 1;


            int min = int.MaxValue;


            for (int i = 0; i < l1; i++)
            {
                int lo = 0, hi = l2;

                if (binaryMatrix.Get(i, l2) == 0)
                {
                    continue;
                }
                else if (binaryMatrix.Get(i, 0) == 1)
                {
                    min = 0;
                    break;
                }
                while (lo < hi)
                {
                    int mid = (hi + lo) / 2;

                    if (binaryMatrix.Get(i, mid) == 1 && binaryMatrix.Get(i, mid - 1) == 0)
                    {
                        min = Math.Min(min, mid);
                        break;
                    }
                    else if (binaryMatrix.Get(i, mid) == 1)
                    {
                        hi = mid - 1;
                    }
                    else
                    {
                        lo = mid;
                    }

                    if (lo + 1 == hi && binaryMatrix.Get(i, lo) == 0 && binaryMatrix.Get(i, hi) == 1)
                    {
                        min = Math.Min(min, hi);
                        break;
                    }
                }
            }

            return min == int.MaxValue ? -1 : min;
        }
    }

}