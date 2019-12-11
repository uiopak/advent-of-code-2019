using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_11
{
    class Program
    {
        enum Direction
        {
            up,
            right,
            down,
            left
        }

        static void Main(string[] args)
        {
            var input = File.ReadAllText("input");
            //var input = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";
            //var input = "104,1125899906842624,99";
            //var input = "1102,34915192,34915192,7,4,7,99,0";
            Dictionary<Tuple<int, int>, int> hull = new Dictionary<Tuple<int, int>, int>();
            Direction direction = Direction.up;
            int x = 0;
            int y = 0;
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
            bool firstOutput = true;
            long firstOutputLong = 0;
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
                        Input(poz + 1, A, inputVal, ref longs, relativeBase, hull, x, y);
                        poz += 2;
                        break;
                    case 4:
                        Output(poz + 1, A, out inputVal, ref longs, relativeBase, ref firstOutput, ref hull, ref x, ref y, ref direction);
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
            Console.WriteLine($"hull painted: {hull.Count}");
            int maxX = 0;
            int maxY = 0;
            int minX = 0;
            int minY = 0;
            
            foreach (var item in hull)
            {
                if (item.Key.Item1 < minX) minX = item.Key.Item1;
                if (item.Key.Item1 > maxX) maxX = item.Key.Item1;
                if (item.Key.Item2 < minY) minY = item.Key.Item2;
                if (item.Key.Item2 > maxY) maxY = item.Key.Item2;
            }
            int a = 12;
            char[,] hullArray = new char[maxX - minX + 1, maxY - minY + 1];
            for (int xi = 0; xi < maxX - minX; xi++)
            {
                for (int yi = 0; yi < maxY - minY; yi++)
                {
                    hullArray[xi, yi] = ' ';
                }
            }
            foreach (var item in hull)
            {
                //hullArray[item.Key.Item1 - minX, item.Key.Item2 - minY] = item.Value == 1 ? '█' : ' ';
                hullArray[item.Key.Item1 - minX, maxY - item.Key.Item2] = item.Value == 1 ? '█' : ' ';
            }
            for (int i = 0; i < maxY - minY +1; i++)
            {
                for (int j = 0; j < maxX - minX + 1; j++)
                {
                    Console.Write(hullArray[j, i]);

                }
                Console.WriteLine();
            }
            int startX = 30;//UZAEKBLP
            int startY = 15;
            foreach (var item in hull)
            {
                //Console.SetCursorPosition(startX + item.Key.Item1, startY + item.Key.Item2);
                Console.SetCursorPosition(startX + item.Key.Item1, startY + maxY - item.Key.Item2);
                Console.Write(item.Value == 1 ? '█' : ' ');

                //if (item.Key.Item1 < minX) minX = item.Key.Item1;
                //if (item.Key.Item1 > maxX) maxX = item.Key.Item1;
                //if (item.Key.Item2 < minY) minY = item.Key.Item2;
                //if (item.Key.Item2 > maxY) maxY = item.Key.Item2;
            }
            Console.SetCursorPosition(0, startY + 7);
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
        static void Input(long a, long A, long inputVal, ref Dictionary<long, long> longs, long relativeBase, Dictionary<Tuple<int, int>, int> dictionary, int x, int y)
        {
            inputVal = 0;
            if (dictionary.ContainsKey(new Tuple<int, int>(x, y)))
            {
                inputVal = dictionary[new Tuple<int, int>(x, y)];
            }
            else if (!dictionary.Any()) inputVal = 1;

            writeToList(ref longs, (
                A == 0 ? readList(ref longs, a) :
                    (readList(ref longs, a) + relativeBase)), inputVal);
            //longs[longs[a]] = inputVal;
        }
        static void Output(long a, long A, out long inputVal, ref Dictionary<long, long> longs, long relativeBase, ref bool firstOutput, ref Dictionary<Tuple<int, int>, int> dictionary, ref int x, ref int y, ref Direction direction)
        {
            inputVal = (
                A == 0 ? readList(ref longs, readList(ref longs, a)) :
                A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
                readList(ref longs, a));
            if (firstOutput)
            {
                if (dictionary.ContainsKey(new Tuple<int, int>(x, y)))
                {
                    dictionary[new Tuple<int, int>(x, y)] = (int)inputVal;
                }
                else
                {
                    dictionary.Add(new Tuple<int, int>(x, y), (int)inputVal);
                }
                firstOutput = false;
            }
            else
            {
                firstOutput = true;
                if (inputVal == 1)
                {
                    direction = (Direction)(((int)direction + 1) % 4);
                }
                else
                {
                    direction = (Direction)(((int)direction - 1) % 4);
                    if (direction < 0) direction += 4;
                }
                switch (direction)
                {
                    case Direction.up: y++; break;
                    case Direction.right: x++; break;
                    case Direction.down: y--; break;
                    case Direction.left: x--; break;
                }

            }
            //Console.WriteLine(
            //    A == 0 ? readList(ref longs, readList(ref longs, a)) :
            //    A == 2 ? readList(ref longs, (readList(ref longs, a) + relativeBase)) :
            //    readList(ref longs, a));
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
