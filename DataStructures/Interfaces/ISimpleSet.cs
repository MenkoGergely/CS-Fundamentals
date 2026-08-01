using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    public interface ISimpleSet<T>
    {
        void Insert(T value);
        bool Contains(T value);
        void Remove(T value);
        void Traverse(Action<T> action);
    }
}
