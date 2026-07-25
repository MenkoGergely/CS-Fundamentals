namespace Optimization.Knapsack.Backtracking;

internal class VisszalepesesHatizsakPakolas
{
    protected HatizsakProblema problema;
    public int LepesSzam { get; protected set; }
    public VisszalepesesHatizsakPakolas(HatizsakProblema problema)
    {
        this.problema = problema;
    }

    public virtual bool[] OptimalisMegoldas()
    {
        int[] M = new int[problema.n];
        bool[,] R = new bool[problema.n, 2];
        for (int i = 0; i < problema.n; i++)
        {
            M[i] = 2;
            R[i, 0] = true;
            R[i, 1] = false;
        }


        var opt = new VisszalepesesOptimalizacio<bool>(problema.n, M, R, ft, fk, josag);

        bool[] optimalis = opt.OptimalisMegoldas();
        LepesSzam = opt.LepesSzam;
        return optimalis;
    }
    protected float josag(bool[] pakolas)
    {
        return problema.OsszErtek(pakolas);

    }
    protected bool ft(int szint, bool E)
    {
        return true;
    }
    protected bool fk(int szint, bool van, bool[] E)
    {
        if (van)
        {
            return problema.OsszSuly(E) + problema.w[szint] <= problema.Wmax;
        }
        return true;

    }
    public float OptimalisErtek()
    {
        bool[] megoldas = OptimalisMegoldas();
        return problema.OsszErtek(megoldas);
    }
}
