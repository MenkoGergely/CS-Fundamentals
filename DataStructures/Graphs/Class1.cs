using DataStructures.Interfaces;
using DataStructures.Trees;
namespace DataStructures.Graphs;

public class EgeszGrafEl : GrafEl<int>, IComparable<EgeszGrafEl>
{

    public int Honnan { get; }
    public int Hova { get; }
    public EgeszGrafEl(int honnan, int hova)
    {
        Honnan = honnan;
        Hova = hova;
    }




    public int CompareTo(EgeszGrafEl? other)
    {
        if (other == null)
            return 1;

        int honnanCompare = this.Honnan.CompareTo(other.Honnan);
        if (honnanCompare != 0)
        {
            return honnanCompare;
        }

        return this.Hova.CompareTo(other.Hova);
    }
}
public class CsucsmatrixSulyozatlanEgeszGraf : SulyozatlanGraf<int, EgeszGrafEl>
{

    int n;
    bool[,] M;

    public CsucsmatrixSulyozatlanEgeszGraf(int n)
    {
        this.n = n;
        M = new bool[n, n];
    }

    public int CsucsokSzama => n;

    public int ElekSzama
    {
        get
        {
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (M[i, j]) { cnt++; }
                }
            }
            return cnt;
        }
    }

    public IDataStructureSet<int> Csucsok
    {
        get
        {
            TreeSet<int> csucsok = new TreeSet<int>();
            for (int i = 0; i < n; i++)
            {
                csucsok.Insert(i);
            }
            return csucsok;
        }
    }

    public IDataStructureSet<EgeszGrafEl> Elek
    {
        get
        {
            TreeSet<EgeszGrafEl> elek = new TreeSet<EgeszGrafEl>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (M[i, j])
                    {
                        EgeszGrafEl el = new EgeszGrafEl(i, j);
                        elek.Insert(el);
                    }
                }
            }
            return elek;
        }
    }

    public IDataStructureSet<int> Szomszedai(int csucs)
    {
        TreeSet<int> szomszedok = new TreeSet<int>();
        for (int j = 0; j < n; j++)
        {
            if (M[csucs, j])
            {
                szomszedok.Insert(j);
            }
        }
        return szomszedok;
    }

    public void UjEl(int honnan, int hova)
    {
        M[honnan, hova] = true;
    }

    public bool VezetEl(int honnan, int hova)
    {
        return M[honnan, hova];
    }
}

public class GrafBejarasok
{
    public static IDataStructureSet<V> SzelessegiBejaras<V, E>(Graf<V, E> g, V start, Action<V> muvelet) where V : IComparable<V>
    {
        Sor<V> S = new LancoltSor<V>();
        Halmaz<V> F = new FaHalmaz<V>();
        S.Sorba(start);
        F.Beszur(start);
        while (!S.Ures)
        {
            V k = S.Sorbol();
            muvelet(k);
            Halmaz<V> szomszedok = g.Szomszedai(k);
            szomszedok.Bejar((x) =>
            {
                if (!F.Eleme(x))
                {
                    S.Sorba(x);
                    F.Beszur(x);
                }
            });
        }
        return F;
    }

    public static Halmaz<V> MelysegiBejaras<V, E>(Graf<V, E> g, V start, Action<V> muvelet) where V : IComparable<V>
    {
        Halmaz<V> F = new FaHalmaz<V>();
        MelysegiBejarasRekurzio(g, start, F, muvelet);
        return F;

    }
    public static void MelysegiBejarasRekurzio<V, E>(Graf<V, E> g, V k, Halmaz<V> F, Action<V> muvelet) where V : IComparable<V>
    {
        F.Beszur(k);
        muvelet(k);
        Halmaz<V> szomszedok = (FaHalmaz<V>)g.Szomszedai(k);
        szomszedok.Bejar((x) =>
        {
            if (!F.Eleme(x))
            {
                MelysegiBejarasRekurzio(g, x, F, muvelet);
            }
        });
    }
}