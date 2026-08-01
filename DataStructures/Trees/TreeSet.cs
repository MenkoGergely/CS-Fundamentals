namespace DataStructures.Trees;
using DataStructures.Interfaces;
internal class TreeSet<T> : ISimpleSet<T> where T : IComparable<T>
{
    TreeNode<T> root;

    public TreeSet()
    {
        root = null;
    }

    public void Traverse(Action<T> action)
    {
        TraverseSubTreePreorder(root, action);
    }

    public void Insert(T value)
    {
        root = InsertIntoSubTree(root, value);
    }

    public bool Contains(T value)
    {
        return SubTreeContains(root, value);
    }

    public void Remove(T value)
    {
        root = RemoveFromSubTree(root, value);
    }
    public static TreeNode<T> InsertIntoSubTree(TreeNode<T> node, T value)
    {
        if (node == null)
        {
            TreeNode<T> newNode = new TreeNode<T>(value, null, null);
            return newNode;
        }
        else
        {
            if (node.Value.CompareTo(value) < 0)
            {
                node.Right = InsertIntoSubTree(node.Right, value);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                node.Left = InsertIntoSubTree(node.Left, value);
            }

            return node;
        }
    }
    public static bool SubTreeContains(TreeNode<T> node, T value)
    {
        if (node != null)
        {
            if (node.Value.CompareTo(value) < 0)
            {
                return SubTreeContains(node.Right, value);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                return SubTreeContains(node.Left, value);
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    protected static TreeNode<T> RemoveFromSubTree(TreeNode<T> node, T value)
    {
        if (node != null)
        {
            if (node.Value.CompareTo(value) < 0)
            {
                node.Right = RemoveFromSubTree(node.Right, value);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                node.Left = RemoveFromSubTree(node.Left, value);
            }
            else
            {
                if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    node.Left = RemoveNodeWithTwoChildren(node, node.Left);
                }
            }
            return node;
        }
        else
        {
            throw new Exception();
        }
    }

    private static TreeNode<T> RemoveNodeWithTwoChildren(TreeNode<T> nodeToDelete, TreeNode<T> current)
    {
        if (current.Right != null)
        {
            current.Right = RemoveNodeWithTwoChildren(nodeToDelete, current.Right);
            return current;
        }
        else
        {
            nodeToDelete.Value = current.Value;
            current = current.Left;
            return current;
        }
    }

    protected void TraverseSubTreePreorder(TreeNode<T> node, Action<T> action)
    {
        if (node != null)
        {
            action(node.Value);
            TraverseSubTreePreorder(node.Left, action);
            TraverseSubTreePreorder(node.Right, action);
        }
    }
    protected void TraverseSubTreeInOrder(TreeNode<T> node, Action<T> action)
    {
        if (node != null)
        {
            TraverseSubTreeInOrder(node.Left, action);
            action(node.Value);
            TraverseSubTreeInOrder(node.Right, action);
        }
    }
    protected void TraverseSubTreePostOrder(TreeNode<T> node, Action<T> action)
    {
        if (node != null)
        {
            TraverseSubTreePostOrder(node.Left, action);
            TraverseSubTreePostOrder(node.Right, action);
            action(node.Value);
        }
    }

}
