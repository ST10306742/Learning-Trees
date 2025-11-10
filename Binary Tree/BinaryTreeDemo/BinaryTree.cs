using System;
using System.Xml;

public class BianryTree
{
    public TreeNode Root;

    public BianryTree()
    {
        Root = null;
    }

    //Insert nodes manually for 1st time learning 
    public void CreateSampleTree()
    {
        Root = new TreeNode(1);
        Root.Left = new TreeNode(2);
        Root.Right = new TreeNode(3);
        Root.Left.Left = new TreeNode(4);
        Root.Left.Right = new TreeNode(5);
    }

    //Print the tree (In order traversal)
    public void PrintInOrder(TreeNode node)
    {
        if (node == null) return;

        PrintInOrder(node.Left);
        Console.WriteLine(node.Value + " ");
        PrintInOrder(node.Right);
    }
}