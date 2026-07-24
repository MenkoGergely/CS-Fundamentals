namespace Data_Structures.Trees
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T value;
        public TreeNode<T> left;
        public TreeNode<T> right;

        public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }

}
