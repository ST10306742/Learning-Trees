// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        BianryTree tree = new BianryTree();
        tree.CreateSampleTree();

        Console.WriteLine("In-Order Traversal:");
        tree.PrintInOrder(tree.Root);
    }
}
