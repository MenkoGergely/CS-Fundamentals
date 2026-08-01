using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    public interface IGraph<V, E>
    {
        int VertexCount { get; }
        int EdgeCount { get; }
        ISimpleSet<V> Vertices { get; }
        ISimpleSet<E> Edges { get; }
        bool HasEdge(V from, V to);
        ISimpleSet<V> Neighbors(V vertex);
    }
}
