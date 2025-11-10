using System;

public class TreeNode
{
    public int Value;          // The value stored in the node
    public TreeNode LeftChild;     // Reference to the left child
    public TreeNode RightChild;    // Reference to the right child
    public int Height;         // Height of this node (used for balancing)

    public TreeNode(int value)
    {
        Value = value;
        Height = 1; // New nodes start with height 1
    }
}
