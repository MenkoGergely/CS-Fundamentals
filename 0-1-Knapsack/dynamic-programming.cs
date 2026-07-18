using OE.ALGA.Optimalizalas;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace OE.ALGA.Optimalizalas
{
    // 8. heti labor feladat - Tesztek: 08_DinamikusProgramozasTesztek.cs
    public class DinamikusHatizsakPakolas
    {
        HatizsakProblema problema;

        public int LepesSzam { private set; get; }
        public DinamikusHatizsakPakolas(HatizsakProblema problema)
        {
            this.problema = problema;
        }

        public float[,] TablazatFeltoltes()
        {
            float[,] F = new float[problema.n + 1, problema.Wmax + 1];
            for (int t = 0; t <= problema.n; t++)
            {
                F[t, 0] = 0;
            }
            for (int h = 0; h <= problema.Wmax; h++)
            {
                F[0, h] = 0;
            }
            for (int t = 1; t <= problema.n; t++)
            {
                for (int h = 1; h <= problema.Wmax; h++)
                {
                    LepesSzam++;
                    if (h < problema.w[t - 1])
                    {

                        F[t, h] = F[t - 1, h];
                    }
                    else
                    {
                        F[t, h] = Math.Max(F[t - 1, h], F[t - 1, h - problema.w[t - 1]] + problema.p[t - 1]);

                    }
                }
            }
            return F;
        }

        public float OptimalisErtek()
        {
            LepesSzam = 0;
            return TablazatFeltoltes()[problema.n, problema.Wmax];

        }
        public bool[] OptimalisMegoldas()
        {
            LepesSzam = 0;
            float[,] F = TablazatFeltoltes();
            bool[] O = new bool[problema.n];
            int t = problema.n;
            int h = problema.Wmax;
            for (int i = 0; i < problema.n; i++)
            {
                O[i] = false;
            }
            while (t > 0 && h > 0)
            {
                if (F[t, h] != F[t - 1, h])
                {
                    O[t - 1] = true;
                    h -= problema.w[t - 1];
                }
                t--;

            }
            return O;

        }


    }
}