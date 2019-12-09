using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_09
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input");
            //var input = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";
            //var input = "104,1125899906842624,99";
            //var input = "1102,34915192,34915192,7,4,7,99,0";
            long inputVal = 2;
            bool part_one = true;
            if (part_one)
            {
                inputVal = 1;
            }
            else
            {
                inputVal = 2;
            }

            long relativeBase = 0;
            var longss = input.Split(',').Select(Int64.Parse).ToArray();
            var longs = new Dictionary<long, long>();
            for (int i = 0; i < longss.Length; i++)
            {
                longs.Add(i, longss[i]);
            }
            long poz = 0;
            bool end = false;
            while (!end)
            {
                long DE = longs[poz] % 100;
                long A = longs[poz] / 100 % 10;
                long B = longs[poz] / 1000 % 10;
                long C = longs[poz] / 10000 % 10;
                switch (DE)
                {
                    case 1:
                        Add(poz + 1, A, poz + 2, B, poz + 3, C, ref longs, relativeBase);
                        poz += 4;
                        break;
                    case 2:
                        Multiplie(poz + 1, A, poz + 2, B, poz + 3, C, ref longs, relativeBase);
                        poz += 4;
                        break;
                    case 3:
                        Input(poz + 1, A, inputVal, ref longs, relativeBase);
                        poz += 2;
                        break;
                    case 4:
                        Output(poz + 1, A, out inputVal, ref longs, relativeBase);
                        poz += 2;
                        break;
                    case 5:
                        JumpIfTrue(poz + 1, A, poz + 2, B, ref poz, ref longs, relativeBase);
                        break;
                    case 6:
                        JumpIfFalse(poz + 1, A, poz + 2, B, ref poz, ref longs, relativeBase);
                        break;
                    case 7:
                        LessThan(poz + 1, A, poz + 2, B, poz + 3, C, ref longs, relativeBase);
                        poz += 4;
                        break;
                    case 8:
                        Equals(poz + 1, A, poz + 2, B, poz + 3, C, ref longs, relativeBase);
                        poz += 4;
                        break;
                    case 9:
                        adjustTheRelativeBase(poz + 1, A, ref longs, ref relativeBase);
                        poz += 2;
                        break;
                    default:
                        end = true;
                        break;
                }
            }
            Console.WriteLine($"0: {longs[0]}");

        }
        static void JumpIfTrue(long a, long A, long b, long B, ref long poz, ref Dictionary<long, long> longs, long relativeBase)
        {
            if ((
                    A == 0 ? readList(ref longs, readList(ref longs, a)) :
                    A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                    readList(ref longs, a)) != 0)
            {
                poz =
                    B == 0 ? readList(ref longs, readList(ref longs, b)) :
                    B == 2 ? readList(ref longs, (readList(ref longs, b)) + relativeBase) :
                    readList(ref longs, b);
            }
            else
            {
                poz += 3;
            }
        }
        static void JumpIfFalse(long a, long A, long b, long B, ref long poz, ref Dictionary<long, long> longs, long relativeBase)
        {
            if ((
                    A == 0 ? readList(ref longs, readList(ref longs, a)) :
                    A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                    readList(ref longs, a)) == 0)
            {
                poz = (
                    B == 0 ? readList(ref longs, readList(ref longs, b)) :
                    B == 2 ? readList(ref longs, (readList(ref longs, b) + relativeBase)) :
                    readList(ref longs, b));
            }
            else
            {
                poz += 3;
            }
        }
        static void LessThan(long a, long A, long b, long B, long c, long C, ref Dictionary<long, long> longs, long relativeBase)
        {
            if ((
                    A == 0 ? readList(ref longs, readList(ref longs, a)) :
                    A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                    readList(ref longs, a)
                    ) < (
                    B == 0 ? readList(ref longs, readList(ref longs, b)) :
                    B == 2 ? readList(ref longs, (readList(ref longs, b) + relativeBase)) :
                    readList(ref longs, b)))
            {
                writeToList(ref longs, C == 0 ? readList(ref longs, c) : (readList(ref longs, c) + relativeBase), 1);
                //longs[longs[c]] = 1;
            }
            else
            {
                writeToList(ref longs, C == 0 ? readList(ref longs, c) : (readList(ref longs, c) + relativeBase), 0);
                //longs[longs[c]] = 0;
            }
        }
        static void Equals(long a, long A, long b, long B, long c, long C, ref Dictionary<long, long> longs, long relativeBase)
        {
            if ((
                    A == 0 ? readList(ref longs, readList(ref longs, a)) :
                    A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                    readList(ref longs, a)
                    ) == (
                    B == 0 ? readList(ref longs, readList(ref longs, b)) :
                    B == 2 ? readList(ref longs, (readList(ref longs, b) + relativeBase)) :
                    readList(ref longs, b)))
            {
                writeToList(ref longs, C == 0 ? readList(ref longs, c) : (readList(ref longs, c) + relativeBase), 1);
                //longs[longs[c]] = 1;
            }
            else
            {
                writeToList(ref longs, C == 0 ? readList(ref longs, c) : (readList(ref longs, c) + relativeBase), 0);
                //longs[longs[c]] = 0;
            }
        }
        static void Add(long a, long A, long b, long B, long c, long C, ref Dictionary<long, long> longs, long relativeBase)
        {
            writeToList(ref longs, C == 0 ? readList(ref longs, c) : (readList(ref longs, c) + relativeBase), (
                    A == 0 ? readList(ref longs, readList(ref longs, a)) :
                    A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                    readList(ref longs, a)
                    ) + (
                    B == 0 ? readList(ref longs, readList(ref longs, b)) :
                    B == 2 ? readList(ref longs, (readList(ref longs, b) + relativeBase)) :
                    readList(ref longs, b)));
            //longs[longs[c]] = (A == 0 ? longs[longs[a]] : A == 2 ? longs[relative_base + a] : longs[a]) + (B == 0 ? longs[longs[b]] : B == 2 ? longs[relative_base + b] : longs[b]);
        }
        static void Input(long a, long A, long inputVal, ref Dictionary<long, long> longs, long relativeBase)
        {
            writeToList(ref longs, (
                A == 0 ? readList(ref longs, a) :
                    (readList(ref longs, a) + relativeBase)), inputVal);
            //longs[longs[a]] = inputVal;
        }
        static void Output(long a, long A, out long inputVal, ref Dictionary<long, long> longs, long relativeBase)
        {
            inputVal = (
                A == 0 ? readList(ref longs, readList(ref longs, a)) :
                A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                readList(ref longs, a));
            Console.WriteLine(
                A == 0 ? readList(ref longs, readList(ref longs, a)) :
                A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                readList(ref longs, a));
        }
        static void Multiplie(long a, long A, long b, long B, long c, long C, ref Dictionary<long, long> longs, long relativeBase)
        {
            writeToList(ref longs, C == 0 ? readList(ref longs, c) : (readList(ref longs, c) + relativeBase),
                (
                    A == 0 ? readList(ref longs, readList(ref longs, a)) :
                    A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                    readList(ref longs, a)
                    ) * (
                    B == 0 ? readList(ref longs, readList(ref longs, b)) :
                    B == 2 ? readList(ref longs, (readList(ref longs, b) + relativeBase)) :
                    readList(ref longs, b)));
            //longs[longs[c]] = (A == 0 ? longs[longs[a]] : A == 2 ? longs[relative_base + a] : longs[a]) * (B == 0 ? longs[longs[b]] : B == 2 ? longs[relative_base + b] : longs[b]);
        }
        static void adjustTheRelativeBase(long a, long A, ref Dictionary<long, long> longs, ref long relativeBase)
        {
            long tmp = relativeBase;
            tmp += (
                A == 0 ? readList(ref longs, readList(ref longs, a)) :
                A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                readList(ref longs, a));
            relativeBase = tmp;
            //Console.WriteLine(A == 0 ? longs[longs[a]] : A == 2 ? longs[relative_base + a] : longs[a]);
        }
        static void writeToList(ref Dictionary<long, long> longs, long index, long value)
        {
            if (!longs.ContainsKey(index))
            {
                longs.Add(index, value);
            }
            else
            {
                longs[index] = value;
            }
        }

        static long readList(ref Dictionary<long, long> longs, long index)
        {
            if (!longs.ContainsKey(index))
            {
                longs.Add(index, 0);
                return 0;
            }
            else
            {
                return longs[index];
            }
        }
    }
}
