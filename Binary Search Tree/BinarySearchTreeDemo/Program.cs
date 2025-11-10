using System;

public class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();

        //insert numbers
        int[] numbers = { 8, 3, 10, 1, 6, 14, 4, 7 };

        foreach (int num in numbers)
        {
            bst.Insert(num);
        }

        //Print sorted Tree (in order traversal)
        Console.WriteLine("In Order Traversal (sorted):");
        bst.InOrder(bst.Root);

        //Search for a number
        Console.WriteLine("\n\nSearch results:");
        Console.WriteLine("Find 6? " + bst.Search(6));
        Console.WriteLine("Find 7? " + bst.Search(9));
    }
}