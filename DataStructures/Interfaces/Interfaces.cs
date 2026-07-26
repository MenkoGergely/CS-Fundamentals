using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    public interface IDataStructureSet<T>
    {
        void Insert(T value);
        bool Contains(T value);
        void Remove(T value);
        void Traverse(Action<T> action);
    }

    public interface GrafEl<V>
    {
        V Honnan { get; }
        V Hova { get; }
    }

    public interface Graf<V, E>
    {
        int CsucsokSzama { get; }
        int ElekSzama { get; }
        IDataStructureSet<V> Csucsok { get; }
        IDataStructureSet<E> Elek { get; }
        bool VezetEl(V honnan, V hova);
        IDataStructureSet<V> Szomszedai(V csucs);
    }

    public interface SulyozatlanGraf<V, E> : Graf<V, E>
    {
        void UjEl(V honnan, V hova);
    }

    public interface SulyozottGrafEl<V> : GrafEl<V>
    {
        float Suly { get; }
    }

    public interface SulyozottGraf<V, E> : Graf<V, E>
    {
        void UjEl(V honnan, V hova, float suly);
        float Suly(V honnan, V hova);
    }
}
