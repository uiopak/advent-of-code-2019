using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            bool part_one = false;
            if (part_one)
            {
                var input = File.ReadAllLines("input");
                //var input = new string[2]
                //{
                //    "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                //    "U62,R66,U55,R34,D71,R55,D58,R83"
                //};
                List<Tuple<int, int>> oneList = new List<Tuple<int, int>>();
                List<Tuple<int, int>> twoList = new List<Tuple<int, int>>();
                int x = 0;
                int y = 0;
                foreach (var s in input[0].Split(','))
                {
                    switch (s[0])
                    {
                        case 'U':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                y++;
                                oneList.Add(new Tuple<int, int>(x, y));
                            }

                            break;
                        case 'L':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                x--;
                                oneList.Add(new Tuple<int, int>(x, y));
                            }

                            break;
                        case 'D':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                y--;
                                oneList.Add(new Tuple<int, int>(x, y));
                            }

                            break;
                        case 'R':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                x++;
                                oneList.Add(new Tuple<int, int>(x, y));
                            }

                            break;
                    }
                }

                int x1 = 0;
                int y1 = 0;
                foreach (var s in input[1].Split(','))
                {
                    switch (s[0])
                    {
                        case 'U':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                y1++;
                                twoList.Add(new Tuple<int, int>(x1, y1));
                            }

                            break;
                        case 'L':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                x1--;
                                twoList.Add(new Tuple<int, int>(x1, y1));
                            }

                            break;
                        case 'D':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                y1--;
                                twoList.Add(new Tuple<int, int>(x1, y1));
                            }

                            break;
                        case 'R':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                x1++;
                                twoList.Add(new Tuple<int, int>(x1, y1));
                            }

                            break;
                    }
                }

                //oneList.Intersect(twoList).Select(el =>
                //    new Tuple<int, int, int>(Math.Abs(el.Item1) + Math.Abs(el.Item2), el.Item1, el.Item2));
                var intersect = oneList.Intersect(twoList);
                var length = intersect.Select(el =>
                    Math.Abs(el.Item1) + Math.Abs(el.Item2));
                Console.WriteLine($"min {length.Min()}");
            }
            else
            {
                var input = File.ReadAllLines("input");
                //var input = new string[2]
                //{
                //    "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                //    "U62,R66,U55,R34,D71,R55,D58,R83"
                //};
                List<Tuple<int, int, int>> oneList = new List<Tuple<int, int, int>>();
                List<Tuple<int, int, int>> twoList = new List<Tuple<int, int, int>>();
                int x = 0;
                int y = 0;
                int length = 0;
                foreach (var s in input[0].Split(','))
                {
                    switch (s[0])
                    {
                        case 'U':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                y++;
                                length++;
                                oneList.Add(new Tuple<int, int, int>(x, y, length));
                            }

                            break;
                        case 'L':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                x--;
                                length++;
                                oneList.Add(new Tuple<int, int, int>(x, y, length));
                            }

                            break;
                        case 'D':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                y--;
                                length++;
                                oneList.Add(new Tuple<int, int, int>(x, y, length));
                            }

                            break;
                        case 'R':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                x++;
                                length++;
                                oneList.Add(new Tuple<int, int, int>(x, y, length));
                            }

                            break;
                    }
                }

                int x1 = 0;
                int y1 = 0;
                int length1 = 0;
                foreach (var s in input[1].Split(','))
                {
                    switch (s[0])
                    {
                        case 'U':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                y1++;
                                length1++;
                                twoList.Add(new Tuple<int, int, int>(x1, y1, length1));
                            }

                            break;
                        case 'L':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                x1--;
                                length1++;
                                twoList.Add(new Tuple<int, int, int>(x1, y1, length1));
                            }

                            break;
                        case 'D':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                y1--;
                                length1++;
                                twoList.Add(new Tuple<int, int, int>(x1, y1, length1));
                            }

                            break;
                        case 'R':
                            for (int i = 1; i <= int.Parse(s.Substring(1)); i++)
                            {
                                x1++;
                                length1++;
                                twoList.Add(new Tuple<int, int, int>(x1, y1, length1));
                            }

                            break;
                    }
                }

                var min1 = oneList.Join(twoList, el => new Tuple<int, int>(el.Item1, el.Item2),
                    el => new Tuple<int, int>(el.Item1, el.Item2),
                    (first, second) => first.Item3 + second.Item3);
                Console.WriteLine($"min {min1.Min()}");

                //List<int> distances = new List<int>();
                //foreach (var tuple in oneList)
                //{
                //    foreach (var tuple1 in twoList)
                //    {
                //        if (tuple.Item1 == tuple1.Item1 && tuple.Item2 == tuple1.Item2)
                //        {
                //            distances.Add(tuple1.Item3 + tuple.Item3);
                //            //break;
                //        }
                //    }
                //}
                //var intersect = oneList.Where(x3=> twoList.Any(y3 => y3.Item1==x3.Item1&&y3.Item2==x3.Item2)).ToList();
                //var length_list = intersect.Select(el =>
                //    Math.Abs(el.Item1) + Math.Abs(el.Item2));
                //Console.WriteLine($"min {length_list.Min()}");
                //Console.WriteLine($"min {distances.Min()}");
            }
        }
    }
}
