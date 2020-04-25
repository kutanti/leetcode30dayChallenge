namespace LeetCode30DayChallenge.Questions
{
    // Time O(n)
    // Space O(1)
    public class PreOrderToBST
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {

            TreeNode node = new TreeNode(preorder[0]);
            for (int i = 1; i < preorder.Length; i++)
            {
                ConvertToBST(node, preorder[i]);
            }

            return node;
        }

        private static TreeNode ConvertToBST(TreeNode node, int val)
        {
            if (node == null)
            {
                node = new TreeNode(val);
                return node;

            }

            if (node.val > val)
            {
                node.left = ConvertToBST(node.left, val);
            }
            else
            {
                node.right = ConvertToBST(node.right, val);
            }
            return node;
        }
    }
}