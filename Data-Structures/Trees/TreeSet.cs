namespace Data_Structures.Trees
{
    public class TreeSet<T> : ITreeSet<T> where T : IComparable<T>
    {
        TreeNode<T> root;

        public TreeSet()
        {
            this.root = null;
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
                if (node.value.CompareTo(value) < 0)
                {
                    node.right = InsertIntoSubTree(node.right, value);
                }
                else if (node.value.CompareTo(value) > 0)
                {
                    node.left = InsertIntoSubTree(node.left, value);
                }

                return node;
            }
        }
        public static bool SubTreeContains(TreeNode<T> node, T value)
        {
            if (node != null)
            {
                if (node.value.CompareTo(value) < 0)
                {
                    return SubTreeContains(node.right, value);
                }
                else if (node.value.CompareTo(value) > 0)
                {
                    return SubTreeContains(node.left, value);
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
                if (node.value.CompareTo(value) < 0)
                {
                    node.right = RemoveFromSubTree(node.right, value);
                }
                else if (node.value.CompareTo(value) > 0)
                {
                    node.left = RemoveFromSubTree(node.left, value);
                }
                else
                {
                    if (node.left == null)
                    {
                        node = node.right;
                    }
                    else if (node.right == null)
                    {
                        node = node.left;
                    }
                    else
                    {
                        node.left = RemoveNodeWithTwoChildren(node, node.left);
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
            if (current.right != null)
            {
                current.right = RemoveNodeWithTwoChildren(nodeToDelete, current.right);
                return current;
            }
            else
            {
                nodeToDelete.value = current.value;
                current = current.left;
                return current;
            }
        }

        protected void TraverseSubTreePreorder(TreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                action(node.value);
                TraverseSubTreePreorder(node.left, action);
                TraverseSubTreePreorder(node.right, action);
            }
        }
        protected void TraverseSubTreeInOrder(TreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                TraverseSubTreeInOrder(node.left, action);
                action(node.value);
                TraverseSubTreeInOrder(node.right, action);
            }
        }
        protected void TraverseSubTreePostOrder(TreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                TraverseSubTreePostOrder(node.left, action);
                TraverseSubTreePostOrder(node.right, action);
                action(node.value);
            }
        }

    }
}
