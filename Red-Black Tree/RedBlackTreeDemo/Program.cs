public class Program
{
    public static void Main()
    {
        RedBlackTree tree = new RedBlackTree();
        int[] values = { 10, 20, 30, 15, 25, 5, 1 };

        foreach (int value in values)
        {
            tree.Insert(value);
        }

        Console.WriteLine("In-order traversal (with colors):");
        tree.PrintTree();
    }
}
