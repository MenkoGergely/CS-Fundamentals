namespace Optimization.Knapsack.Backtracking;

internal class VisszalepesesOptimalizacio<T>
{
    protected int n;
    protected int[] M;
    protected T[,] R;
    protected Func<int, T, bool> ft;
    protected Func<int, T, T[], bool> fk;
    protected Func<T[], float> josag;

    public int LepesSzam { get; protected set; }
    public VisszalepesesOptimalizacio(int n, int[] m, T[,] r, Func<int, T, bool> ft, Func<int, T, T[], bool> fk, Func<T[], float> josag)
    {
        this.n = n;
        M = m;
        R = r;
        this.ft = ft;
        this.fk = fk;
        this.josag = josag;
    }

    public virtual T[] OptimalisMegoldas()
    {
        bool van = false;
        T[] E = new T[n];
        T[] O = new T[n];
        BackTrack(0, ref E, ref van, ref O);
        if (van)
        {
            return O;
        }
        else
            throw new Exception("Nincs megoldas");
    }


    protected virtual void BackTrack(int szint, ref T[] E, ref bool van, ref T[] O)
    {
        int i = 0;
        while (i < M[szint])
        {

            LepesSzam++;
            if (ft(szint, R[szint, i]))
            {
                if (fk(szint, R[szint, i], E))
                {
                    E[szint] = R[szint, i];
                    if (szint + 1 == n)
                    {
                        if (!van || josag(E) > josag(O))
                        {
                            for (int k = 0; k < n; k++)
                                O[k] = E[k];

                        }
                        van = true;

                    }
                    else
                    {
                        BackTrack(szint + 1, ref E, ref van, ref O);
                    }
                }
            }
            i++;
        }

    }


}





