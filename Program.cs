using System;
using System.Numerics;
using static System.Console;

namespace irreducible_sum_rationals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[,] { { 1, 2 }, { 2, 9 }, { 3, 18 }, { 4, 24 }, { 6, 48 } };
            // int[,] a = new int[,] { { 1, 2 }, { 1, 3 }, { 1, 4 } };
            SumFracts(a);
        }

        public static string SumFracts(int[,] l)
        {
            BigInteger rn = 0, rd = 1;
            var elements = l.GetUpperBound(0);
            if (elements <= 0) return null;
            for (var i = 0; i <= elements; ++i)
            {
                BigInteger n = (BigInteger)l[i, 0], d = (BigInteger)l[i, 1];
                BigInteger lcm = rd * d / BigInteger.GreatestCommonDivisor(rd, d);
                n *= lcm / d;
                rn *= lcm / rd;
                rn += n;
                rd = lcm;
                BigInteger gcd = BigInteger.GreatestCommonDivisor(rn, rd);
                rn /= gcd;
                rd /= gcd;


            }
            WriteLine($"[{rn}, {rd}]");
            return (rd == 1) ? $"{rn}" : $"[{rn}, {rd}]";

        }
    }
}
