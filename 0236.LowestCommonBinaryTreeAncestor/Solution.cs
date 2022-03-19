namespace _0236.LowestCommonBinaryTreeAncestor;

public class Solution
{
    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == p || root == q) return root;

        var stack = new Stack<TreeNode>();
        var parent = new Dictionary<TreeNode, TreeNode>();
        stack.Push(root);
        parent.Add(root, null);

        var qFound = false;
        var pFound = false;
        while (stack.Any() && (!qFound || !pFound))
        {
            var current = stack.Pop();
            qFound = qFound || current == q;
            pFound = pFound || current == p;
            if (current.left != null)
            {
                stack.Push(current.left);
                parent.Add(current.left, current);
            }
            if (current.right != null)
            {
                stack.Push(current.right);
                parent.Add(current.right, current);
            }
        }

        var pParents = new HashSet<TreeNode>();
        var rent = p;
        while (rent != null)
        {
            pParents.Add(rent);
            rent = parent[rent];
        }

        while (q != null)
        {
            if (pParents.Contains(q)) return q;
            q = parent[q];
        }

        return null;
    }
}


public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
