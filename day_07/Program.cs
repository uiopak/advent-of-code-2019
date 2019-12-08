using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace day_07
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input");

            bool zad1 = false;
            if (zad1)
            {
                //var input = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0";
                //var input = "3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0";
                //var input = "3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0";
                List<Tuple<int, Tuple<int, int, int, int, int>>> allOuts = new List<Tuple<int, Tuple<int, int, int, int, int>>>();
                for (int i = 0; i < 5; i++)
                {
                    int inputVal = 0;
                    int pozi = 0;
                    string inputi = input;
                    bool resumei = false;
                    bool resumej = false;
                    bool resumek = false;
                    bool resumel = false;
                    bool resumem = false;

                    inputVal = runProgram(ref inputi, inputVal, i, ref pozi,ref resumei);
                    for (int j = 0; j < 5; j++)
                    {
                        string inputj = input;
                        int pozj = 0;

                        if (j == i) continue;
                        int inputValj = runProgram(ref inputj, inputVal, j, ref pozj, ref resumej);
                        for (int k = 0; k < 5; k++)
                        {
                            string inputk = input;
                            int pozk = 0;

                            if (k == i || k == j) continue;
                            int inputValk = runProgram(ref inputk, inputValj, k, ref pozk, ref resumek);
                            for (int l = 0; l < 5; l++)
                            {
                                string inputl = input;
                                int pozl = 0;
                                if (l == i || l == j || l == k) continue;
                                int inputVall = runProgram(ref inputl, inputValk, l, ref pozl, ref resumel);
                                for (int m = 0; m < 5; m++)
                                {
                                    string inputm = input;

                                    int pozm = 0;
                                    if (m == i || m == j || m == k || m == l) continue;
                                    int inputValm = runProgram(ref inputm, inputVall, m, ref pozm, ref resumem);
                                    allOuts.Add(new Tuple<int, Tuple<int, int, int, int, int>>(inputValm, new Tuple<int, int, int, int, int>(i, j, k, l, m)));
                                }
                            }
                        }
                    }
                }

                var finalList = allOuts.Where(r => r.Item1 == (allOuts.Max(m => m.Item1))).ToList();
                Console.WriteLine(finalList.First().Item1);
                //int a = 0;
            }
            else
            {
                //var input = "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10";
                //var input = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5";
                List<Tuple<int, Tuple<int, int, int, int, int>>> allOuts = new List<Tuple<int, Tuple<int, int, int, int, int>>>();
                for (int i = 5; i < 10; i++)
                {
                    for (int j = 5; j < 10; j++)
                    {
                        if (j == i) continue;
                        for (int k = 5; k < 10; k++)
                        {
                            if (k == i || k == j) continue;
                            for (int l = 5; l < 10; l++)
                            {
                                if (l == i || l == j || l == k) continue;
                                for (int m = 5; m < 10; m++)
                                {
                                    if (m == i || m == j || m == k || m == l) continue;
                                    int inputVal = 0;
                                    string inputi = input;
                                    string inputj = input;
                                    string inputk = input;
                                    string inputl = input;
                                    string inputm = input;
                                    int pozi = 0;
                                    int pozj = 0;
                                    int pozk = 0;
                                    int pozl = 0;
                                    int pozm = 0;
                                    bool resumei = true;
                                    bool resumej = true;
                                    bool resumek = true;
                                    bool resumel = true;
                                    bool resumem = true;
                                    while (resumem)
                                    {
                                        inputVal = runProgram(ref inputi, inputVal, i, ref pozi, ref resumei);
                                        inputVal = runProgram(ref inputj, inputVal, j, ref pozj, ref resumej);
                                        inputVal = runProgram(ref inputk, inputVal, k, ref pozk, ref resumek);
                                        inputVal = runProgram(ref inputl, inputVal, l, ref pozl, ref resumel);
                                        inputVal = runProgram(ref inputm, inputVal, m, ref pozm, ref resumem);
                                    }
                                    allOuts.Add(new Tuple<int, Tuple<int, int, int, int, int>>(inputVal, new Tuple<int, int, int, int, int>(i, j, k, l, m)));
                                }
                            }
                        }
                    }
                }

                var finalList = allOuts.Where(r => r.Item1 == (allOuts.Max(m => m.Item1))).ToList();
                Console.WriteLine(finalList.First().Item1);
                //int a = 0;
            }
        }

        static int runProgram(ref string input, int inputVal, int phase, ref int poz, ref bool resume )
        {
            var ints = input.Split(',').Select(Int32.Parse).ToArray();
            //var ints = Array.ConvertAll(input.Split(','), Int32.Parse);
            bool first = !(poz != 0);
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
                        Input(poz + 1, A, phase, inputVal, ref first, ints);
                        poz += 2;
                        break;
                    case 4:
                        Output(poz + 1, A, out inputVal, ints);
                        poz += 2;
                        end = true;
                        break;
                    case 5:
                        JumpIfTrue(poz + 1, A, poz + 2, B, ref poz, ints);
                        break;
                    case 6:
                        JumpIfFalse(poz + 1, A, poz + 2, B, ref poz, ints);
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
                        resume = false;
                        end = true;
                        break;
                }
            }
            input = string.Join(",",ints);
            return inputVal;
            //Console.WriteLine($"0: {ints[0]}");
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
            if ((A == 0 ? ints[ints[a]] : ints[a]) < (B == 0 ? ints[ints[b]] : ints[b]))
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
        static void Add(int a, int A, int b, int B, int c, int C, in int[] ints)
        {
            ints[ints[c]] = (A == 0 ? ints[ints[a]] : ints[a]) + (B == 0 ? ints[ints[b]] : ints[b]);
        }
        static void Input(int a, int A, int phase, int inputVal, ref bool first, in int[] ints)
        {

            if (first)
            {
                ints[ints[a]] = phase;
                first = false;
            }
            else
            {
                ints[ints[a]] = inputVal;
            }
        }
        static void Output(int a, int A, out int inputVal, in int[] ints)
        {
            inputVal = A == 0 ? ints[ints[a]] : ints[a];
            //Console.WriteLine(inputVal);
        }
        static void Multiplie(int a, int A, int b, int B, int c, int C, in int[] ints)
        {
            ints[ints[c]] = (A == 0 ? ints[ints[a]] : ints[a]) * (B == 0 ? ints[ints[b]] : ints[b]);
        }
    }
}
