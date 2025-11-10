using System;

public class RedBlackTree
{
    private RBNode root;

    //Left Rotation
    private void RotateLeft(RBNode x)
    {
        RBNode y = x.Right;
        x.Right = y.Left;

        if (y.Left != null)
            y.Left.Parent = x;

        y.Parent = x.Parent;

        if (x.Parent == null)
            root = y;
        else if (x == x.Parent.Left)
            x.Parent.Left = y;

        y.Left = x;
        x.Parent = y;
    }

    //Right Rotation
    private void RotateRight(RBNode y)
    {
        RBNode x = y.Left;
        y.Left = x.Right;

        if (x.Right != null)
            x.Right.Parent = y;

        x.Parent = y.Parent;

        if (y.Parent == null)
            root = x;
        else if (y == y.Parent.Right)
            y.Parent.Right = x;
        else
            y.Parent.Left = x;

        x.Right = y;
        y.Parent = x;
    }

    //Fix Violations
    private void FixInsertion(RBNode node)
    {
        while (node != root && node.Parent.NodeColor == Color.Red)
        {
            RBNode parent = node.Parent;
            RBNode grandparent = parent.Parent;

            // Parent is left child of grandparent
            if (parent == grandparent.Left)
            {
                RBNode uncle = grandparent.Right;

                // Case 1: Uncle is red -> recolor
                if (uncle != null && uncle.NodeColor == Color.Red)
                {
                    parent.NodeColor = Color.Black;
                    uncle.NodeColor = Color.Black;
                    grandparent.NodeColor = Color.Red;
                    node = grandparent;
                }
                else
                {
                    // Case 2: Node is right child -> rotate left
                    if (node == parent.Right)
                    {
                        node = parent;
                        RotateLeft(node);
                    }

                    // Case 3: Node is left child -> rotate right
                    parent.NodeColor = Color.Black;
                    grandparent.NodeColor = Color.Red;
                    RotateRight(grandparent);
                }
            }
            else
            {
                RBNode uncle = grandparent.Left;

                if (uncle != null && uncle.NodeColor == Color.Red)
                {
                    parent.NodeColor = Color.Black;
                    uncle.NodeColor = Color.Black;
                    grandparent.NodeColor = Color.Red;
                    node = grandparent;
                }
                else
                {
                    if (node == parent.Left)
                    {
                        node = parent;
                        RotateRight(node);
                    }

                    parent.NodeColor = Color.Black;
                    grandparent.NodeColor = Color.Red;
                    RotateLeft(grandparent);
                }
            }
        }
        root.NodeColor = Color.Black; // Root is always black
    }

    // Insert node
    public void Insert(int value)
    {
        RBNode newNode = new RBNode(value);
        RBNode parent = null;
        RBNode current = root;

        // Normal BST insert
        while (current != null)
        {
            parent = current;
            if (newNode.Value < current.Value)
                current = current.Left;
            else
                current = current.Right;
        }

        newNode.Parent = parent;

        if (parent == null)
            root = newNode; // Tree was empty
        else if (newNode.Value < parent.Value)
            parent.Left = newNode;
        else
            parent.Right = newNode;

        // Fix red-black rules
        FixInsertion(newNode);
    }

    // Inorder Traversal (sorted output)
    private void InOrder(RBNode node)
    {
        if (node != null)
        {
            InOrder(node.Left);
            Console.Write($"{node.Value}({node.NodeColor}) ");
            InOrder(node.Right);
        }
    }

    public void PrintTree()
    {
        InOrder(root);
        Console.WriteLine();
    }
}