using System;
using System.IO;
using System.Linq;

namespace day_02
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
                ints[1] = 12;
                ints[2] = 2;
                int poz = 0;
                bool end = false;
                while (!end)
                {
                    switch (ints[poz])
                    {
                        case 1:
                            Add(poz + 1, poz + 2, poz + 3, ints);
                            break;
                        case 2:
                            Multiplie(poz + 1, poz + 2, poz + 3, ints);
                            break;
                        default:
                            end = true;
                            break;
                    }
                    poz += 4;
                }
                Console.WriteLine($"0: {ints[0]}");
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {

                        var ints = input.Split(',').Select(Int32.Parse).ToArray();
                        ints[1] = i;
                        ints[2] = j;
                        int poz = 0;
                        bool end = false;
                        while (!end)
                        {
                            switch (ints[poz])
                            {
                                case 1:
                                    Add(poz + 1, poz + 2, poz + 3, ints);
                                    break;
                                case 2:
                                    Multiplie(poz + 1, poz + 2, poz + 3, ints);
                                    break;
                                default:
                                    end = true;
                                    break;
                            }
                            poz += 4;
                        }

                        if (ints[0] == 19690720) Console.WriteLine($"0: {ints[0]} 1: {i} 2: {j} 100 * 1 + 2 = {100 * i + j}");
                    }
                }
            }
        }
        static void Add(int a, int b, int c, in int[] ints)
        {
            ints[ints[c]] = ints[ints[a]] + ints[ints[b]];
        }
        static void Multiplie(int a, int b, int c, in int[] ints)
        {
            ints[ints[c]] = ints[ints[a]] * ints[ints[b]];
        }
    }
}
