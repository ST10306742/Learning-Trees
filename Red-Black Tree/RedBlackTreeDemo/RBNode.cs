using System;

public enum Color {Red, Black}

public class RBNode
{
    public int Value;
    public Color NodeColor;
    public RBNode Left, Right, Parent;

    public RBNode(int value)
    {
        Value = value;
        NodeColor = Color.Red; //New nodes are always red first
    }
}