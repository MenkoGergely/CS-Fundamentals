using DataStructures.Interfaces;
using DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class GraphTraversals
    {
        public static ISimpleSet<V> BreadthFirstSearch<V, E>(IGraph<V, E> g, V start, Action<V> action) where V : IComparable<V>
        {
            Queue<V> queue = new Queue<V>();
            ISimpleSet<V> visited = new TreeSet<V>();
            queue.Enqueue(start);
            visited.Insert(start);
            while (queue.Count > 0)
            {
                V current = queue.Dequeue();
                action(current);
                ISimpleSet<V> neighbors = g.Neighbors(current);
                neighbors.Traverse((neighbor) =>
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Insert(neighbor);
                    }
                });
            }
            return visited;
        }
        public static ISimpleSet<V> DepthFirstSearch<V, E>(IGraph<V, E> g, V start, Action<V> action) where V : IComparable<V>
        {
            ISimpleSet<V> visited = new TreeSet<V>();
            DepthFirstSearchRecursive(g, start, visited, action);
            return visited;
        }
        public static void DepthFirstSearchRecursive<V, E>(IGraph<V, E> g, V current, ISimpleSet<V> visited, Action<V> action) where V : IComparable<V>
        {
            visited.Insert(current);
            action(current);
            ISimpleSet<V> neighbors = (TreeSet<V>)g.Neighbors(current);
            neighbors.Traverse((neighbor) =>
            {
                if (!visited.Contains(neighbor))
                {
                    DepthFirstSearchRecursive(g, neighbor, visited, action);
                }
            });
        }
    }
}
