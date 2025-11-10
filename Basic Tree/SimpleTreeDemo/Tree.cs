using System;

public class Tree
{
    //gain tree root node(1st node in tree)
    public TreeNode Root { get; set; }

    //class constructor to initialise root node 
    public Tree(string rootValue)
    {
        Root = new TreeNode(rootValue);
    }

    //Recursive method to print the tree structure
    public void PrintTree(TreeNode node, string indent = "")
    {
        Console.WriteLine(indent = "- " + node.Value);

        foreach(var child in node.Children)
        {
            PrintTree(child, indent + " ");
        }
    }
}