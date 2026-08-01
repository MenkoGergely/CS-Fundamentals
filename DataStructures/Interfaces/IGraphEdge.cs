using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    public interface IGraphEdge<V>
    {
        V From { get; }
        V To { get; }
    }
}
