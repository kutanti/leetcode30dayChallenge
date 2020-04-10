namespace LeetCode30DayChallenge.Questions
{
    using System.Collections.Generic;
    using System;
    public class QMiddleNode
    {
        /*
        Given a non-empty, singly linked list with head node head, return a middle node of linked list.

If there are two middle nodes, return the second middle node.
        */
        public ListNode MiddleNode(ListNode head)
        {

            ListNode dummy = head;
            int count = 0;

            while (head != null)
            {
                count++;
                head = head.next;
            }

            int midPos = (count / 2) + 1;
            count = 1;
            while (dummy != null && midPos > count)
            {
                dummy = dummy.next;
                count++;
            }

            return dummy;

        }
    }


    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}