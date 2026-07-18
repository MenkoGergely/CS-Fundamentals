using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;

namespace OE.ALGA.Optimalizalas
{
    // 9. heti labor feladat - Tesztek: 09VisszalepesesKeresesTesztek.cs
    public class VisszalepesesOptimalizacio<T>
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

    public class VisszalepesesHatizsakPakolas
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

    public class SzetvalasztasEsKorlatozasOptimalizacio<T> : VisszalepesesOptimalizacio<T>
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

    public class SzetvalasztasEsKorlatozasHatizsakPakolas : VisszalepesesHatizsakPakolas
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
}