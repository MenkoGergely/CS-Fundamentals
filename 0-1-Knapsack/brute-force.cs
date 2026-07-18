using System;

namespace OE.ALGA.Optimalizalas
{
    // 7. heti labor feladat - Tesztek: 07_NyersEroTesztek.cs
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
    public class NyersEro<T>
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
                if (josag(x) > (josag(O)))
                {
                    O = x;
                }
            }
            return O;
        }
    }

    public class NyersEroHatizsakPakolas
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
                K[j] = (int)((szam / Math.Pow(2, j)) % 2) == 1;
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
}