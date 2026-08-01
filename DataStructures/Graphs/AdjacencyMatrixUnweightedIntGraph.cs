using DataStructures.Interfaces;
using DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class AdjacencyMatrixUnweightedIntGraph : IUnweightedGraph<int, IntGraphEdge>
    {
        int vertexCount;
        bool[,] adjacencyMatrix;
        public AdjacencyMatrixUnweightedIntGraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            adjacencyMatrix = new bool[vertexCount, vertexCount];
        }
        public int VertexCount => vertexCount;
        public int EdgeCount
        {
            get
            {
                int count = 0;
                for (int i = 0; i < vertexCount; i++)
                {
                    for (int j = 0; j < vertexCount; j++)
                    {
                        if (adjacencyMatrix[i, j]) { count++; }
                    }
                }
                return count;
            }
        }
        public ISimpleSet<int> Vertices
        {
            get
            {
                TreeSet<int> vertices = new TreeSet<int>();
                for (int i = 0; i < vertexCount; i++)
                {
                    vertices.Insert(i);
                }
                return vertices;
            }
        }
        public ISimpleSet<IntGraphEdge> Edges
        {
            get
            {
                TreeSet<IntGraphEdge> edges = new TreeSet<IntGraphEdge>();
                for (int i = 0; i < vertexCount; i++)
                {
                    for (int j = 0; j < vertexCount; j++)
                    {
                        if (adjacencyMatrix[i, j])
                        {
                            IntGraphEdge edge = new IntGraphEdge(i, j);
                            edges.Insert(edge);
                        }
                    }
                }
                return edges;
            }
        }
        public ISimpleSet<int> Neighbors(int vertex)
        {
            TreeSet<int> neighbors = new TreeSet<int>();
            for (int j = 0; j < vertexCount; j++)
            {
                if (adjacencyMatrix[vertex, j])
                {
                    neighbors.Insert(j);
                }
            }
            return neighbors;
        }
        public void AddEdge(int from, int to)
        {
            adjacencyMatrix[from, to] = true;
        }
        public bool HasEdge(int from, int to)
        {
            return adjacencyMatrix[from, to];
        }
    }
}
