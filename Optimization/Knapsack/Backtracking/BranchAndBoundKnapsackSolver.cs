namespace Optimization.Knapsack.Backtracking;

internal class SzetvalasztasEsKorlatozasHatizsakPakolas : VisszalepesesHatizsakPakolas
{
    public SzetvalasztasEsKorlatozasHatizsakPakolas(HatizsakProblema problema) : base(problema)
    {
    }

    public override bool[] OptimalisMegoldas()
    {
        int[] M = new int[problema.n];
        bool[,] R = new bool[problema.n, 2];
        for (int i = 0; i < M.Length; i++)
        {
            M[i] = 2;
            R[i, 0] = true;
            R[i, 1] = false;
        }

        var opt = new SzetvalasztasEsKorlatozasOptimalizacio<bool>(problema.n, M, R, ft, fk, josag, fb);
        bool[] optimalis = opt.OptimalisMegoldas();
        LepesSzam = opt.LepesSzam;
        return optimalis;
    }

    private float fb(int szint, bool[] E)
    {
        float b = 0;
        for (int i = szint; i < E.Length; i++)
        {
            if (problema.OsszSuly(E) + problema.w[i] <= problema.Wmax)
                b += problema.p[i];
        }
        return b;
    }
    public float OptimalisErtek()
    {
        bool[] megoldas = OptimalisMegoldas();
        return problema.OsszErtek(megoldas);
    }
}
