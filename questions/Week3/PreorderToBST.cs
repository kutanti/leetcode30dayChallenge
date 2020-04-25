namespace LeetCode30DayChallenge.Questions
{

    public class PreOrderToBST
    {
        // Time O(n^2)
        // Space O(1)
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

        int start = 0;

        // this is optimized, O(n) time.
        private TreeNode preOrderToBstHelper(int[] preorder, int min, int max)
        {
            int n = preorder.Length;
            if (start >= n)
            {
                return null;
            }
            if (preorder[start] < min || preorder[start] > max)
            {
                return null;
            }
            TreeNode node = new TreeNode(preorder[start]);
            start++;
            node.left = preOrderToBstHelper(preorder, min, node.val - 1);
            node.right = preOrderToBstHelper(preorder, node.val + 1, max);
            return node;
        }
    }
}