namespace Optimization.Knapsack
{
    public class HatizsakProblema
    {
        public int n { get; }
        public int Wmax { get; }
        public int[] w { get; }
        public float[] p { get; }

        public HatizsakProblema(int n, int wmax, int[] w, float[] p)
        {
            this.n = n;
            Wmax = wmax;
            this.w = w;
            this.p = p;
        }

        public int OsszSuly(bool[] pakolas)
        {

            int osszSuly = 0;
            for (int i = 0; i < n; i++)
            {
                if (pakolas[i])
                    osszSuly += w[i];
            }
            return osszSuly;


        }

        public float OsszErtek(bool[] pakolas)
        {

            float osszErtek = 0;
            for (int i = 0; i < n; i++)
            {
                if (pakolas[i])
                    osszErtek += p[i];
            }
            return osszErtek;


        }

        public bool Ervenyes(bool[] pakolas)
        {
            return OsszSuly(pakolas) <= Wmax;
        }
    }
}
