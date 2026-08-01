namespace DataStructures.Interfaces
{


    public interface IUnweightedGraph<V, E> : IGraph<V, E>
    {
        void AddEdge(V from, V to);
    }




}
