
using _0236.LowestCommonBinaryTreeAncestor;

var root = new TreeNode(3);
root.left = new TreeNode(5);
root.left.left = new TreeNode(6);
root.left.right = new TreeNode(2);
root.left.right.left = new TreeNode(7);
root.left.right.right = new TreeNode(4);
root.right = new TreeNode(1);

Solution.LowestCommonAncestor(root, root.left, root.left.right.right);
