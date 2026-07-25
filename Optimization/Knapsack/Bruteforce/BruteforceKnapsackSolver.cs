namespace Optimization.Knapsack.Bruteforce;

internal class NyersEroHatizsakPakolas
{
    HatizsakProblema problema;
    public int LepesSzam { get; private set; }

    public NyersEroHatizsakPakolas(HatizsakProblema problema)
    {
        this.problema = problema;
    }

    public bool[] Generator(int i)
    {
        int szam = i;
        bool[] K = new bool[problema.n];
        for (int j = 0; j < problema.n; j++)
        {
            K[j] = (int)(szam / Math.Pow(2, j) % 2) == 1;
        }
        return K;

    }

    public float Josag(bool[] pakolas)
    {
        if (!problema.Ervenyes(pakolas)) return -1;
        else
        {
            return problema.OsszErtek(pakolas);
        }
    }

    public bool[] OptimalisMegoldas()
    {
        NyersEro<bool[]> pakolas = new NyersEro<bool[]>((int)Math.Pow(2, problema.n), Generator, Josag);
        bool[] megoldas = pakolas.OptimalisMegoldas();
        LepesSzam = pakolas.LepesSzam;
        return megoldas;
    }
    public float OptimalisErtek()
    {
        return problema.OsszErtek(OptimalisMegoldas());
    }
}
