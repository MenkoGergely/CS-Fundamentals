namespace DataStructures.Trees;

internal class TreeNode<T> where T : IComparable<T>
{
    public T Value;
    public TreeNode<T> Left;
    public TreeNode<T> Right;

    public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
    {
        this.Value = value;
        this.Left = left;
        this.Right = right;
    }
}
