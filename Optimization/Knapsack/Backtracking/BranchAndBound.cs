namespace Optimization.Knapsack.Backtracking;

internal class SzetvalasztasEsKorlatozasOptimalizacio<T> : VisszalepesesOptimalizacio<T>
{
    protected Func<int, T[], float> fb;
    public SzetvalasztasEsKorlatozasOptimalizacio(int n, int[] m, T[,] r, Func<int, T, bool> ft, Func<int, T, T[], bool> fk, Func<T[], float> josag, Func<int, T[], float> fb) : base(n, m, r, ft, fk, josag)
    {
        this.fb = fb;
    }
    protected override void BackTrack(int szint, ref T[] E, ref bool van, ref T[] O)
    {
        int i = 0;
        while (i < M[szint])
        {
            i++;
            LepesSzam++;
            if (ft(szint, R[szint, i - 1]))
            {
                if (fk(szint, R[szint, i - 1], E))
                {
                    E[szint] = R[szint, i - 1];
                    if (szint == n - 1)
                    {
                        if (!van || josag(E) > josag(O))
                        {
                            for (int i2 = 0; i2 < n; i2++)
                            {
                                O[i2] = E[i2];
                            }
                            van = true;
                        }
                    }
                    else
                    {
                        if (josag(E) + fb(szint, E) > josag(O))
                        {
                            BackTrack(szint + 1, ref E, ref van, ref O);
                        }
                    }
                }

            }

        }
    }

    public override T[] OptimalisMegoldas()
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
            throw new Exception("nincs megoldas");
    }
}
