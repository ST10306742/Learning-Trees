using System;

public class Program
{
    static void Main(string[] args)
    {
        //Step 1: Create the root node
        Tree company = new Tree("CEO");

        //Step 2: Add children to the root node
        TreeNode manager1 = new TreeNode("Manager 1");
        TreeNode manager2 = new TreeNode("Manager 2");
        company.Root.AddChild(manager1);
        company.Root.AddChild(manager2);

        //Step 3: Add sub-children (children to other children)
        manager1.AddChild(new TreeNode("Employee A"));
        manager1.AddChild(new TreeNode("Employee B"));
        manager2.AddChild(new TreeNode("Employee C"));

        //Step 4: Print the entire Tree
        Console.WriteLine("Company Hierarcy:");
        company.PrintTree(company.Root);
    }
}