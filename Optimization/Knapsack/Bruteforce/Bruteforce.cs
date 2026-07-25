namespace Optimization.Knapsack.Bruteforce;


internal class NyersEro<T>
{
    int m;
    Func<int, T> generator;
    Func<T, float> josag;
    public int LepesSzam { get; private set; }

    public NyersEro(int m, Func<int, T> generator, Func<T, float> josag)
    {
        this.m = m;
        this.generator = generator;
        this.josag = josag;
    }


    public T OptimalisMegoldas()
    {
        T O = generator(1);
        for (int i = 2; i <= m; i++)
        {
            LepesSzam++;
            T x = generator(i);
            if (josag(x) > josag(O))
            {
                O = x;
            }
        }
        return O;
    }
}