using System;
using System.IO;
using System.Linq;

namespace day_05
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input");
            bool zad1 = false;
            if (zad1)
            {
                var ints = input.Split(',').Select(Int32.Parse).ToArray();
                int inputVal = 1;
                int poz = 0;
                bool end = false;
                while (!end)
                {
                    int DE = ints[poz] % 100;
                    int A = ints[poz] / 100 % 10;
                    int B = ints[poz] / 1000 % 10;
                    int C = ints[poz] / 10000 % 10;
                    switch (DE)
                    {
                        case 1:
                            Add(poz + 1,A, poz + 2,B, poz + 3,C, ints);
                            poz += 4;
                            break;
                        case 2:
                            Multiplie(poz + 1, A, poz + 2, B, poz + 3, C, ints);
                            poz += 4;
                            break;
                        case 3:
                            Input(poz + 1,A,inputVal, ints);
                            poz += 2;
                            break;
                        case 4:
                            Output(poz + 1, A,out inputVal, ints);
                            poz += 2;
                            break;
                        default:
                            end = true;
                            break;
                    }
                }
                Console.WriteLine($"0: {ints[0]}");
            }
            else
            {
                var ints = input.Split(',').Select(Int32.Parse).ToArray();
                int inputVal = 5;
                int poz = 0;
                bool end = false;
                while (!end)
                {
                    int DE = ints[poz] % 100;
                    int A = ints[poz] / 100 % 10;
                    int B = ints[poz] / 1000 % 10;
                    int C = ints[poz] / 10000 % 10;
                    switch (DE)
                    {
                        case 1:
                            Add(poz + 1, A, poz + 2, B, poz + 3, C, ints);
                            poz += 4;
                            break;
                        case 2:
                            Multiplie(poz + 1, A, poz + 2, B, poz + 3, C, ints);
                            poz += 4;
                            break;
                        case 3:
                            Input(poz + 1, A, inputVal, ints);
                            poz += 2;
                            break;
                        case 4:
                            Output(poz + 1, A, out inputVal, ints);
                            poz += 2;
                            break;
                        case 5:
                            JumpIfTrue(poz + 1, A, poz + 2, B,ref poz, ints);
                            break;
                        case 6:
                            JumpIfFalse(poz + 1, A, poz + 2, B,ref poz, ints);
                            break;
                        case 7:
                            LessThan(poz + 1, A, poz + 2, B, poz + 3, C, ints);
                            poz += 4;
                            break;
                        case 8:
                            Equals(poz + 1, A, poz + 2, B, poz + 3, C, ints);
                            poz += 4;
                            break;
                        default:
                            end = true;
                            break;
                    }
                }
                Console.WriteLine($"0: {ints[0]}");
            }
        }
        static void JumpIfTrue(int a, int A, int b, int B, ref int poz, in int[] ints)
        {
            if ((A == 0 ? ints[ints[a]] : ints[a]) != 0)
            {
                poz = (B == 0 ? ints[ints[b]] : ints[b]);
            }
            else
            {
                poz += 3;
            }
        }
        static void JumpIfFalse(int a, int A, int b, int B, ref int poz, in int[] ints)
        {
            if ((A == 0 ? ints[ints[a]] : ints[a]) == 0)
            {
                poz = (B == 0 ? ints[ints[b]] : ints[b]);
            }
            else
            {
                poz += 3;
            }
        }
        static void LessThan(int a, int A, int b, int B, int c, int C, in int[] ints)
        {
            if ((A == 0 ? ints[ints[a]] : ints[a])< (B == 0 ? ints[ints[b]] : ints[b]))
            {
                ints[ints[c]] = 1;
            }
            else
            {
                ints[ints[c]] = 0;
            }
        }
        static void Equals(int a, int A, int b, int B, int c, int C, in int[] ints)
        {
            if ((A == 0 ? ints[ints[a]] : ints[a]) == (B == 0 ? ints[ints[b]] : ints[b]))
            {
                ints[ints[c]] = 1;
            }
            else
            {
                ints[ints[c]] = 0;
            }
        }
        static void Add(int a,int A, int b,int B, int c,int C, in int[] ints)
        {
            ints[ints[c]] = (A==0? ints[ints[a]]: ints[a]) + (B == 0 ? ints[ints[b]]: ints[b]);
        }
        static void Input(int a, int A,int inputVal, in int[] ints)
        {
            ints[ints[a]] = inputVal;
        }
        static void Output(int a, int A,out int inputVal, in int[] ints)
        {
            inputVal = A == 0 ? ints[ints[a]] : ints[a];
            Console.WriteLine(A == 0 ? ints[ints[a]] : ints[a]);
        }
        static void Multiplie(int a, int A, int b, int B, int c, int C, in int[] ints)
        {
            ints[ints[c]] = (A == 0 ? ints[ints[a]] : ints[a]) * (B == 0 ? ints[ints[b]] : ints[b]);
        }
    }
}
