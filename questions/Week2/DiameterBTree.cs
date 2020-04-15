namespace LeetCode30DayChallenge.Questions
{
    using System;
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class DiameterBTree
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {

            /* base case if tree is empty */
            if (root == null)
                return 0;

            /* get the height of left and right sub trees */
            int lheight = height(root.left);
            int rheight = height(root.right);

            /* get the diameter of left and right subtrees */
            int ldiameter = DiameterOfBinaryTree(root.left);
            int rdiameter = DiameterOfBinaryTree(root.right);

            /* Return max of following three 
              1) Diameter of left subtree 
             2) Diameter of right subtree 
             3) Height of left subtree + height of right subtree */
            return Math.Max(lheight + rheight,
                            Math.Max(ldiameter, rdiameter));
        }

        static int height(TreeNode node)
        {
            /* base case tree is empty */
            if (node == null)
                return 0;

            /* If tree is not empty then height = 1 + max of left 
               height and right heights */
            return (1 + Math.Max(height(node.left), height(node.right)));
        }
    }
}