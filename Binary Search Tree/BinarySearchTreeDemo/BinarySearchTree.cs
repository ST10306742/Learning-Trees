using System;

public class BinarySearchTree
{
    public TreeNode Root;
    public BinarySearchTree()
    {
        Root = null;
    }

    //Insert a new value
    public void Insert(int value)
    {
        Root = InsertRecursively(Root, value);
    }

    private TreeNode InsertRecursively(TreeNode node, int value)
    {
        //if node is null, create a new one
        if (node == null)
        {
            return new TreeNode(value);
        }

        //If smaller, go left
        if (value < node.Value)
        {
            node.Left = InsertRecursively(node.Left, value);
        }
        else
        {
            if (value > node.Value)
            {
                node.Right = InsertRecursively(node.Right, value);
            }
        }

        return node;
    }

    public void InOrder(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        InOrder(node.Left);
        Console.WriteLine(node.Value + " ");
        InOrder(node.Right);
    }

    public bool Search(int value)
    {
        return SearchRecursively(Root, value);
    }

    public bool SearchRecursively(TreeNode node, int value)
    {
        if (node == null) return false;

        if (node.Value == value)
            return true;
        else if (value < node.Value)
            return SearchRecursively(node.Left, value);
        else
            return SearchRecursively(node.Right, value);
    }

    /*
        What is the difference between Binary Trees and Binary Search Trees?

            --> Binary trees just show how each node is connected
            --> No rules in terms of order
            --> Can have a maximum of 2 children per parent:
                * Left child 
                * Right child

                                WHILE

            --> Binary Search trees focuses on the structure of the tree
            --> Is used to identify Nodes
            --> Basically a Binary Tree with extra constraints:
                * Every node follows: Left child < Parent < Right Child
    */
}