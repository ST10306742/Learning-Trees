using System;

public class Program
{
    static void Main(string [] args){
        AVLTree tree = new AVLTree();
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(30);
        tree.Insert(40);
        tree.Insert(50);
        tree.Insert(25);

        Console.WriteLine("AVL Tree (in order)");
        tree.Print();
    }
}