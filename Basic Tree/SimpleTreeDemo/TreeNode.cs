using System;

public class TreeNode
{
    //value that is entered into the data structure
    public string Value { get; set; }
    //children list
    public List<TreeNode> Children { get; set; }

    //class constructor
    public TreeNode(string value)
    {
        Value = value;
        Children = new List<TreeNode>();
    }

    //Add a child to the node
    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }
}

/*
Diagram of how the tree should look:
         A
       / | \
      B  C  D
         / \
        E   F

A is the root node (1st node of the tree)
B & C are A's children
E & F are C's children
B, D, E, & F are leaf nodes(nodes that do not have children)
*/