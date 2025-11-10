public class AVLTree
{
    private TreeNode root; // Root node of the tree

    // Get the height of a node safely
    private int GetHeight(TreeNode currentNode)
    {
        return currentNode == null ? 0 : currentNode.Height;
    }

    // Calculate the balance factor (left height - right height)
    private int GetBalance(TreeNode currentNode)
    {
        return currentNode == null ? 0 : GetHeight(currentNode.LeftChild) - GetHeight(currentNode.RightChild);
    }

    // Right Rotation (used in Left-Left case)
    private TreeNode RotateRight(TreeNode unbalancedNode)
    {
        TreeNode newRoot = unbalancedNode.LeftChild;
        TreeNode tempNode = newRoot.RightChild;

        // Perform rotation
        newRoot.RightChild = unbalancedNode;
        unbalancedNode.LeftChild = tempNode;

        // Update heights
        unbalancedNode.Height = Math.Max(GetHeight(unbalancedNode.LeftChild), GetHeight(unbalancedNode.RightChild)) + 1;
        newRoot.Height = Math.Max(GetHeight(newRoot.LeftChild), GetHeight(newRoot.RightChild)) + 1;

        return newRoot;
    }

    // 🔄 Left Rotation (used in Right-Right case)
    private TreeNode RotateLeft(TreeNode unbalancedNode)
    {
        TreeNode newRoot = unbalancedNode.RightChild;
        TreeNode tempNode = newRoot.LeftChild;

        // Perform rotation
        newRoot.LeftChild = unbalancedNode;
        unbalancedNode.RightChild = tempNode;

        // Update heights
        unbalancedNode.Height = Math.Max(GetHeight(unbalancedNode.LeftChild), GetHeight(unbalancedNode.RightChild)) + 1;
        newRoot.Height = Math.Max(GetHeight(newRoot.LeftChild), GetHeight(newRoot.RightChild)) + 1;

        return newRoot;
    }

    // Recursive insert method
    private TreeNode Insert(TreeNode currentNode, int newValue)
    {
        // 1️⃣ Normal BST insertion
        if (currentNode == null)
            return new TreeNode(newValue);

        if (newValue < currentNode.Value)
            currentNode.LeftChild = Insert(currentNode.LeftChild, newValue);
        else if (newValue > currentNode.Value)
            currentNode.RightChild = Insert(currentNode.RightChild, newValue);
        else
            return currentNode; // No duplicate values allowed

        // 2️⃣ Update height of the current node
        currentNode.Height = 1 + Math.Max(GetHeight(currentNode.LeftChild), GetHeight(currentNode.RightChild));

        // 3️⃣ Check balance factor to detect imbalance
        int balance = GetBalance(currentNode);

        // 4️⃣ Fix the imbalance (4 possible cases)

        // Case 1: Left-Left
        if (balance > 1 && newValue < currentNode.LeftChild.Value)
            return RotateRight(currentNode);

        // Case 2: Right-Right
        if (balance < -1 && newValue > currentNode.RightChild.Value)
            return RotateLeft(currentNode);

        // Case 3: Left-Right
        if (balance > 1 && newValue > currentNode.LeftChild.Value)
        {
            currentNode.LeftChild = RotateLeft(currentNode.LeftChild);
            return RotateRight(currentNode);
        }

        // Case 4: Right-Left
        if (balance < -1 && newValue < currentNode.RightChild.Value)
        {
            currentNode.RightChild = RotateRight(currentNode.RightChild);
            return RotateLeft(currentNode);
        }

        // Return the (possibly updated) node pointer
        return currentNode;
    }

    // Public method for inserting data
    public void Insert(int value)
    {
        root = Insert(root, value);
    }

    // In-order traversal to print sorted tree values
    private void InOrderTraversal(TreeNode currentNode)
    {
        if (currentNode != null)
        {
            InOrderTraversal(currentNode.LeftChild);
            Console.Write(currentNode.Value + " ");
            InOrderTraversal(currentNode.RightChild);
        }
    }

    public void Print()
    {
        Console.WriteLine("Inorder traversal (sorted values):");
        InOrderTraversal(root);
        Console.WriteLine();
    }
}

/*
    An AVL tree defined as a self-balancing Binary Search Tree (BST) where 
    the difference between heights of left and right subtrees for any node 
    cannot be more than one.

    Balance Factor = left subtree height - right subtree height
    For a Balanced Tree(for every node): -1 ≤ Balance Factor ≤ 1

    (http://geeksforgeeks.org/dsa/introduction-to-avl-tree/)
*/