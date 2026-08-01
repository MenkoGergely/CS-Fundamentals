using DataStructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class IntGraphEdge : IGraphEdge<int>, IComparable<IntGraphEdge>
    {
        public int From { get; }
        public int To { get; }
        public IntGraphEdge(int from, int to)
        {
            From = from;
            To = to;
        }
        public int CompareTo(IntGraphEdge? other)
        {
            if (other == null)
                return 1;
            int fromCompare = this.From.CompareTo(other.From);
            if (fromCompare != 0)
            {
                return fromCompare;
            }
            return this.To.CompareTo(other.To);
        }
    }
}
