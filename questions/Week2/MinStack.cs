namespace LeetCode30DayChallenge.Questions
{
    using System.Collections.Generic;

    public class MinStack
    {

        /** initialize your data structure here. */
        Stack<int> stack = null;
        Stack<int> minStack = null;

        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);

            if (minStack.Count == 0 || minStack.Peek() >= x)
            {
                minStack.Push(x);
            }
        }

        public void Pop()
        {
            if (minStack.Count != 0 && stack.Peek() == minStack.Peek())
            {
                minStack.Pop();
            }
            stack.Pop();
        }

        public int Top()
        {
            return stack.Count > 0 ? stack.Peek() : -1;
        }

        public int GetMin()
        {
            return minStack.Count > 0 ? minStack.Peek() : -1;
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}