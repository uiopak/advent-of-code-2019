using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = File.CreateText("out.txt");
            var input = File.ReadAllLines("input");
            var input2 = "......#.#.\n" +
"#..#.#....\n" +
"..#######.\n" +
".#.#.###..\n" +
".#..#.....\n" +
"..#....#.#\n" +
"#..#....#.\n" +
".##.#..###\n" +
"##...#..#.\n" +
".#....####";
            var input3 =
                "#.#...#.#.\n" +
                ".###....#.\n" +
                ".#....#...\n" +
                "##.#.#.#.#\n" +
                "....#.#.#.\n" +
                ".##..###.#\n" +
                "..#...##..\n" +
                "..##....##\n" +
                "......#...\n" +
                ".####.###.";
            var input4 =
".#..##.###...#######\n" +
"##.############..##.\n" +
".#.######.########.#\n" +
".###.#######.####.#.\n" +
"#####.##.#.##.###.##\n" +
"..#####..#.#########\n" +
"####################\n" +
"#.####....###.#.#.##\n" +
"##.#################\n" +
"#####.##.###..####..\n" +
"..######..##.#######\n" +
"####.##.####...##..#\n" +
".#####..#.######.###\n" +
"##...#.##########...\n" +
"#.##########.#######\n" +
".####.#.###.###.#.##\n" +
"....##.##.###..#####\n" +
".#.#.###########.###\n" +
"#.#.#.#####.####.###\n" +
"###.##.####.##.#..##";
            var input5 =
".#....#####...#..\n" +
"##...##.#####..##\n" +
"##...#...#.#####.\n" +
"..#.....#...###..\n" +
"..#.#.....#....##";
            //input = input4.Split("\n").ToArray();
            bool part_one = true;
            List<Tuple<int, int, int>> list = new List<Tuple<int, int, int>>();
            if (part_one)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        if (input[i][j] != '.')
                        {
                            list.Add(new Tuple<int, int, int>(i, j, 0));
                        }
                    }
                }
                List<Tuple<int, Dictionary<double, Tuple<int, List<Tuple<int, int>>>>>> all = new List<Tuple<int, Dictionary<double, Tuple<int, List<Tuple<int, int>>>>>>();
                List<Dictionary<double, List<Tuple<int, int>>>> asterlist = new List<Dictionary<double, List<Tuple<int, int>>>>();
                for (int i = 0; i < list.Count; i++)
                {
                    //Dictionary<double,List<Tuple<int, int>>> aster = new Dictionary<double, List<Tuple<int, int>>>();
                    Dictionary<double, Tuple<int, List<Tuple<int, int>>>> tmp = new Dictionary<double, Tuple<int, List<Tuple<int, int>>>>();
                    List<Tuple<double, int>> tmp_list = new List<Tuple<double, int>>();
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (i == j) continue;
                        double angle; //= (list[i].Item1 - list[j].Item1) / (list[i].Item2 - list[j].Item2);
                        int x = (list[i].Item2 - list[j].Item2);
                        int y = (list[i].Item1 - list[j].Item1);
                        //var n = 270 - (Math.Atan2(y, x)) * 180 / Math.PI;
                        //var xc = n % 360;
                        angle = Math.Atan2(y, x) - (Math.PI / 2);
                        if (angle < 0) angle += 2 * Math.PI;
                        //angle = xc;
                        //if (x ==0 && y>0)
                        //{
                        //    angle = Math.PI/2;
                        //}
                        //else if(x == 0 && y > 0)
                        //{
                        //}
                        //if ((list[i].Item2 - list[j].Item2) < 0)
                        //{
                        //    angle = 270 - (Math.Atan((list[i].Item1 - list[j].Item1) / -(list[i].Item2 - list[j].Item2)) * 180 / Math.PI);
                        //}
                        //else
                        //{
                        //    angle = 90 + (Math.Atan((list[i].Item1 - list[j].Item1) / (list[i].Item2 - list[j].Item2)) * 180 / Math.PI);
                        //}
                        var tm = new Tuple<double, bool, bool>(angle, (list[i].Item1 - list[j].Item1) >= 0, (list[i].Item2 - list[j].Item2) >= 0);
                        if (tmp.ContainsKey(angle))
                        {
                            var frtg = tmp[angle];
                            var tmplist = frtg.Item2;
                            tmplist.Add(new Tuple<int, int>(list[j].Item2, list[j].Item1));
                            var test = new Tuple<int, List<Tuple<int, int>>>(frtg.Item1 + 1, tmplist);
                            tmp[angle] = test;
                            //frtg.Item1 = 0;
                        }
                        else
                        {
                            tmp.Add(angle, new Tuple<int, List<Tuple<int, int>>>(1, new List<Tuple<int, int>>() { new Tuple<int, int>(list[j].Item2, list[j].Item1) }));
                        }
                    }
                    all.Add(new Tuple<int, Dictionary<double, Tuple<int, List<Tuple<int, int>>>>>(i, tmp));
                }
                var my = all.Where(el => el.Item2.Count == all.Max(m => m.Item2.Count)).First();
                int myX = list[my.Item1].Item2;
                int myY = list[my.Item1].Item1;
                Console.WriteLine(all.Max(m => m.Item2.Count));

                //var my = all.Where(el => el.Item2.Count == all.Max(m => m.Item2.Count)).First();
                List<Tuple<int, int>> asters = new List<Tuple<int, int>>();
                var arr = input.ToArray();
                StringBuilder sb2 = new StringBuilder(arr[myY]);
                char boomChar = ' ';
                sb2[myX] = '@';
                arr[myY] = sb2.ToString();
                //arr[1][1] = '%';
                int cnt = 1;
                Tuple<int, Dictionary<double, Tuple<int, List<Tuple<int, int>>>>> my2 = new Tuple<int, Dictionary<double, Tuple<int, List<Tuple<int, int>>>>>(my.Item1,new Dictionary<double, Tuple<int, List<Tuple<int, int>>>>());
                bool start = false;
                //Console.Write($"{cnt++} boom at ");
                //Console.WriteLine();
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
                while (true)
                {
                    if(my.Item2.Count==0&&my2.Item2.Count!=0)
                    {
                        start = true;
                    }
                    if(start)
                    {
                        my = my2;
                        my2 = new Tuple<int, Dictionary<double, Tuple<int, List<Tuple<int, int>>>>>(my.Item1, new Dictionary<double, Tuple<int, List<Tuple<int, int>>>>());
                        start = false;
                    }
                    var one = my.Item2.Where(el => el.Key <= Math.PI / 2 && el.Key >= 0);
                    var two = my.Item2.Where(el => el.Key >= 3 * Math.PI / 2 && el.Key <= 2 * Math.PI);
                    var three = my.Item2.Where(el => el.Key >= Math.PI && el.Key < 3 * Math.PI / 2);
                    var four = my.Item2.Where(el => el.Key <= Math.PI && el.Key > Math.PI / 2);
                    if (one.Count() > 0)
                    {
                        var found = one.Where(ell => ell.Key == one.Min(el => el.Key)).First();
                        //var sorted = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item1 - myX) + Math.Abs(el.Item2 - myY));
                        var element = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item1 - myX) + Math.Abs(el.Item2 - myY)).First();
                        Console.SetCursorPosition(0, 0);
                        if (asters.Contains(new Tuple<int, int>(element.Item1, element.Item2)))
                        {
                            int asf = 123;
                        }
                        Console.Write($"{cnt++} boom at x: {element.Item1}, y: {element.Item2} w 1");
                        fs.Write($"{element.Item1},{element.Item2}\n");
                        int x = element.Item1;
                        int y = element.Item2;
                        Console.SetCursorPosition(x, 1 + y);
                        Console.Write(boomChar);
                        //StringBuilder sb = new StringBuilder(arr[y]);
                        //sb[x] = boomChar;
                        //arr[y] = sb.ToString();
                        //arr[y].Replace()

                        if (found.Value.Item1 == 1)
                        {
                            asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            my.Item2.Remove(found.Key);
                        }
                        else
                        {
                            //Console.WriteLine("powinien usuwać najbliższy a nie pierwszy z listy");
                            //asters.Add(new Tuple<int, int>(found.Value.Item2.First().Item1, found.Value.Item2.First().Item2));
                            //my.Item2[found.Key].Item2.Remove(my.Item2[found.Key].Item2.First());
                            //var element = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item2 - myX) + Math.Abs(el.Item2 - myY)).First();
                            asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            my.Item2[found.Key].Item2.Remove(element);
                            var tmptuple = new Tuple<int, List<Tuple<int, int>>>(my.Item2[found.Key].Item1 - 1, my.Item2[found.Key].Item2);
                            //my.Item2[found.Key] = tmptuple;
                            my.Item2.Remove(found.Key);
                            my2.Item2.Add(found.Key, tmptuple);
                            //my.Item2[found.Key].Item1--;
                        }
                    }
                    else if (four.Count() > 0)
                    {
                        var found = four.Where(ell => ell.Key == four.Min(el => el.Key)).First();
                        //var sorted = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item1 - myX) + Math.Abs(el.Item2 - myY));
                        var element = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item1 - myX) + Math.Abs(el.Item2 - myY)).First();
                        Console.SetCursorPosition(0, 0);
                        if (asters.Contains(new Tuple<int, int>(element.Item1, element.Item2)))
                        {
                            int asf = 123;
                        }
                        Console.Write($"{cnt++} boom at x: {element.Item1}, y: {element.Item2} w 4");
                        fs.Write($"{element.Item1},{element.Item2}\n");
                        int x = element.Item1;
                        int y = element.Item2;
                        Console.SetCursorPosition(x, 1 + y);
                        Console.Write(boomChar);
                        //StringBuilder sb = new StringBuilder(arr[y]);
                        //sb[x] = boomChar;
                        //arr[y] = sb.ToString();
                        if (found.Value.Item1 == 1)
                        {
                            asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            my.Item2.Remove(found.Key);
                        }
                        else
                        {
                            //asters.Add(new Tuple<int, int>(found.Value.Item2.First().Item1, found.Value.Item2.First().Item2));
                            //my.Item2[found.Key].Item2.Remove(my.Item2[found.Key].Item2.OrderBy(el => Math.Abs( el.Item2-myX)+ Math.Abs(el.Item2 - myY)).First());
                            //var tmptuple = new Tuple<int, List<Tuple<int, int>>>(my.Item2[found.Key].Item1 - 1, my.Item2[found.Key].Item2);
                            //my.Item2[found.Key].Item2.Remove(my.Item2[found.Key].Item2.First());
                            //var element = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item2 - myX) + Math.Abs(el.Item2 - myY)).First();
                            //asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            //my.Item2[found.Key].Item2.Remove(element);
                            //var tmptuple = new Tuple<int, List<Tuple<int, int>>>(my.Item2[found.Key].Item1 - 1, my.Item2[found.Key].Item2);
                            ////my.Item2[found.Key] = tmptuple;
                            //my2.Item2.Add(found.Key, tmptuple);
                            //my.Item2[found.Key].Item1--;
                            asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            my.Item2[found.Key].Item2.Remove(element);
                            var tmptuple = new Tuple<int, List<Tuple<int, int>>>(my.Item2[found.Key].Item1 - 1, my.Item2[found.Key].Item2);
                            //my.Item2[found.Key] = tmptuple;
                            my.Item2.Remove(found.Key);
                            my2.Item2.Add(found.Key, tmptuple);
                        }
                    }
                    else if (three.Count() > 0)
                    {
                        var found = three.Where(ell => ell.Key == three.Min(el => el.Key)).First();
                        //var sorted = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item1 - myX) + Math.Abs(el.Item2 - myY));
                        var element = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item1 - myX) + Math.Abs(el.Item2 - myY)).First();
                        Console.SetCursorPosition(0, 0);
                        if (asters.Contains(new Tuple<int, int>(element.Item1, element.Item2)))
                        {
                            int asf = 123;
                        }
                        Console.Write($"{cnt++} boom at x: {element.Item1}, y: {element.Item2} w 3");
                        fs.Write($"{element.Item1},{element.Item2}\n");
                        int x = element.Item1;
                        int y = element.Item2;
                        Console.SetCursorPosition(x, 1 + y);
                        Console.Write(boomChar);
                        //StringBuilder sb = new StringBuilder(arr[y]);
                        //sb[x] = boomChar;
                        //arr[y] = sb.ToString();
                        if (found.Value.Item1 == 1)
                        {
                            asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            my.Item2.Remove(found.Key);
                        }
                        else
                        {
                            //var element = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item2 - myX) + Math.Abs(el.Item2 - myY)).First();
                            //asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            //my.Item2[found.Key].Item2.Remove(element);
                            ////my.Item2[found.Key].Item2.Remove(my.Item2[found.Key].Item2.First());

                            //var tmptuple = new Tuple<int, List<Tuple<int, int>>>(my.Item2[found.Key].Item1 - 1, my.Item2[found.Key].Item2);
                            ////my.Item2[found.Key] = tmptuple;
                            //my.Item2.Remove(found.Key);
                            //my2.Item2.Add(found.Key, tmptuple);
                            //my.Item2[found.Key].Item1--;
                            asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            my.Item2[found.Key].Item2.Remove(element);
                            var tmptuple = new Tuple<int, List<Tuple<int, int>>>(my.Item2[found.Key].Item1 - 1, my.Item2[found.Key].Item2);
                            //my.Item2[found.Key] = tmptuple;
                            my.Item2.Remove(found.Key);
                            my2.Item2.Add(found.Key, tmptuple);
                        }
                    }
                    else if (two.Count() > 0)
                    {
                        var found = two.Where(ell => ell.Key == two.Min(el => el.Key)).First();
                        //var sorted = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item1 - myX) + Math.Abs(el.Item2 - myY));
                        var element = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item1 - myX) + Math.Abs(el.Item2 - myY)).First();
                        Console.SetCursorPosition(0, 0);
                        if (asters.Contains(new Tuple<int, int>(element.Item1, element.Item2)))
                        {
                            int asf = 123;
                        }
                        Console.Write($"{cnt++} boom at x: {element.Item1}, y: {element.Item2} w 2");
                        fs.Write($"{element.Item1},{element.Item2}\n");
                        int x = element.Item1;
                        int y = element.Item2;
                        Console.SetCursorPosition(x, 1+y);
                        Console.Write(boomChar);
                        //StringBuilder sb = new StringBuilder(arr[y]);
                        //sb[x] = boomChar;
                        //arr[y] = sb.ToString();
                        if (found.Value.Item1 == 1)
                        {
                            asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            my.Item2.Remove(found.Key);
                        }
                        else
                        {
                            //asters.Add(new Tuple<int, int>(found.Value.Item2.First().Item1, found.Value.Item2.First().Item2));
                            //my.Item2[found.Key].Item2.Remove(my.Item2[found.Key].Item2.First());
                            //var element = my.Item2[found.Key].Item2.OrderBy(el => Math.Abs(el.Item2 - myX) + Math.Abs(el.Item2 - myY)).First();
                            //asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            //my.Item2[found.Key].Item2.Remove(element);
                            //var tmptuple = new Tuple<int, List<Tuple<int, int>>>(my.Item2[found.Key].Item1 - 1, my.Item2[found.Key].Item2);
                            ////my.Item2[found.Key] = tmptuple;
                            //my.Item2.Remove(found.Key);
                            //my2.Item2.Add(found.Key, tmptuple);
                            ////my.Item2[found.Key].Item1--;
                            asters.Add(new Tuple<int, int>(element.Item1, element.Item2));
                            my.Item2[found.Key].Item2.Remove(element);
                            var tmptuple = new Tuple<int, List<Tuple<int, int>>>(my.Item2[found.Key].Item1 - 1, my.Item2[found.Key].Item2);
                            //my.Item2[found.Key] = tmptuple;
                            my.Item2.Remove(found.Key);
                            my2.Item2.Add(found.Key, tmptuple);
                        }
                    }
                    else break;
                    //Console.WriteLine($"\n");
                    //foreach (var item in arr)
                    //{
                    //    Console.WriteLine(item);
                    //}
                    //Console.WriteLine($"\n");
                    if (cnt - 1 == 200)
                    {
                        int asfg = 12;
                    }
                    int ad = 12;
                }
                Console.WriteLine("a");
            }
            else
            {

            }
            fs.Flush();
            fs.Close();
        }
    }
}
