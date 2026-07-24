namespace Data_Structures.Trees
{
    public interface ITreeSet<T>
    {
        void Insert(T value);
        bool Contains(T value);
        void Remove(T value);
        void Traverse(Action<T> action);
    }
}
