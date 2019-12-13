using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day_12
{
    class Program
    {
        public class moon
        {
            public int x;
            public int y;
            public int z;
            public int vx = 0;
            public int vy = 0;
            public int vz = 0;
            public string s;

            public moon(string str)
            {
                s = str;
                var res = Regex.Matches(str, "-?\\d+");
                x = int.Parse(res[0].ToString());
                y = int.Parse(res[1].ToString());
                z = int.Parse(res[2].ToString());
            }

            public override string ToString()
            {
                return $"pos=<x= {x}, y= {y}, z= {z}>, vel=<x= {vx}, y= {vy}, z= {vz}>";
            }

            public int kineticEnergy()
            {
                return Math.Abs(vx) + Math.Abs(vy) + Math.Abs(vz);
            }

            public int totalEnergy()
            {
                return (Math.Abs(x)+ Math.Abs(y)+ Math.Abs(z))* kineticEnergy();
            }
        }
        static void Main(string[] args)
        {
            //var input = File.ReadAllText("input");
            var input = File.ReadAllLines("input");
            //var input2 = "<x=-1, y=0, z=2>\n<x=2, y=-10, z=-7>\n<x=4, y=-8, z=8>\n<x=3, y=5, z=-1>";
            //var input3 = "<x=-8, y=-10, z=0>\n<x=5, y=5, z=10>\n<x=2, y=-7, z=3>\n<x=9, y=-8, z=-3>";
            //var input = input2.Split('\n');
            //input.Split(',').Select(Int64.Parse).ToArray();
            //Console.WriteLine(uint.MaxValue);
            bool part_one = true;
            if (part_one)
            {
                long maxsteps = long.MaxValue;
                //moon[] moons = new moon[4]
                //{
                //    new moon(input[0]),
                //    new moon(input[1]),
                //    new moon(input[2]),
                //    new moon(input[3])
                //};
                moon[] moonsX = new moon[4]
                {
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                moon[] moonsY = new moon[4]
                {
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                moon[] moonsZ = new moon[4]
                {
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                //List<moon> moons = new List<moon>();
                //foreach (var s in input)
                //{
                //    moons.Add(new moon(s));
                //}
                //Console.WriteLine($"After 0 steps:");
                //foreach (var moon in moons)
                //{
                //    Console.WriteLine(moon);
                //}
                Console.WriteLine();
                //moon[] moonsLast = new moon [4]
                //{
                //    new moon(input[0]), 
                //    new moon(input[1]), 
                //    new moon(input[2]), 
                //    new moon(input[3])
                //};
                moon[] moonsLastX = new moon[4]
                {
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                moon[] moonsLastY = new moon[4]
                {
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                moon[] moonsLastZ = new moon[4]
                {
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                //List<moon> moonsLast= new List<moon>();
                //List<moon> moonsStart= new List<moon>();
                //moon[] moonsStart = new moon [4]{
                //    new moon(input[0]),
                //    new moon(input[1]),
                //    new moon(input[2]),
                //    new moon(input[3])
                //};
                moon[] moonsStartX = new moon[4]{
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                moon[] moonsStartY = new moon[4]{
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                moon[] moonsStartZ = new moon[4]{
                    new moon(input[0]),
                    new moon(input[1]),
                    new moon(input[2]),
                    new moon(input[3])
                };
                //foreach (var moon in moons)
                //{
                //    moonsLast.Add(new moon(moon.s));
                //    moonsStart.Add(new moon(moon.s));
                //}
                int moonsCnt = 4;
                long x = 0;
                for (long i = 1; i <= maxsteps; i++)
                {
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        moonsLastX[j].x = moonsX[j].x;
                        //moonsLastX[j].y = moonsX[j].y;
                        //moonsLastX[j].z = moonsX[j].z;
                    }
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        for (int k = j; k < moonsCnt; k++)
                        {
                            if (moonsX[j].x < moonsX[k].x)
                            {
                                moonsX[j].vx++;
                                moonsX[k].vx--;
                            }
                            else if (moonsX[j].x > moonsX[k].x)
                            {
                                moonsX[j].vx--;
                                moonsX[k].vx++;
                            }
                            //if (moons[j].y < moons[k].y)
                            //{
                            //    moons[j].vy++;
                            //    moons[k].vy--;
                            //}
                            //else if (moons[j].y > moons[k].y)
                            //{
                            //    moons[j].vy--;
                            //    moons[k].vy++;
                            //}
                            //if (moons[j].z < moons[k].z)
                            //{
                            //    moons[j].vz++;
                            //    moons[k].vz--;
                            //}
                            //else if (moons[j].z > moons[k].z)
                            //{
                            //    moons[j].vz--;
                            //    moons[k].vz++;
                            //}
                        }
                    }

                    for (int j = 0; j < moonsCnt; j++)
                    {
                        moonsX[j].x += moonsX[j].vx;
                        //moons[j].y += moons[j].vy;
                        //moons[j].z += moons[j].vz;
                    }

                    bool exact = true;
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        if (moonsX[j].x!= moonsLastX[j].x
                            //|| moons[j].y != moonsLast[j].y 
                            //|| moons[j].z != moonsLast[j].z
                            || moonsX[j].x != moonsStartX[j].x 
                            //|| moons[j].y != moonsStart[j].y 
                            //|| moons[j].z != moonsStart[j].z
                            )
                        {
                            exact = false;
                            break;
                        }
                    }

                    if (exact)
                    {
                        int a = 12;
                        x = i;
                        Console.WriteLine(i);
                        break;
                    }

                    //if (i == 4686774924)
                    //{
                    //    Console.WriteLine("nie wykr");
                    //    int a = 12;
                    //    break;
                    //}
                    //int kin = 0;
                    //for (int j = 0; j < moons.Count; j++)
                    //{
                    //    kin += Math.Abs(moons[j].kineticEnergy());
                    //}

                    //if (kin==0)
                    //{
                    //    int a = 12;
                    //}
                    //Console.WriteLine($"After {i} steps:");
                    //foreach (var moon in moons)
                    //{
                    //    Console.WriteLine(moon);
                    //}
                    //Console.WriteLine();

                }

                long y = 0;
                for (long i = 1; i <= maxsteps; i++)
                {
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        //moonsLastY[j].x = moonsY[j].x;
                        moonsLastY[j].y = moonsY[j].y;
                        //moonsLastY[j].z = moonsY[j].z;
                    }
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        for (int k = j; k < moonsCnt; k++)
                        {
                            if (moonsY[j].y < moonsY[k].y)
                            {
                                moonsY[j].vy++;
                                moonsY[k].vy--;
                            }
                            else if (moonsY[j].y > moonsY[k].y)
                            {
                                moonsY[j].vy--;
                                moonsY[k].vy++;
                            }
                            //if (moons[j].y < moons[k].y)
                            //{
                            //    moons[j].vy++;
                            //    moons[k].vy--;
                            //}
                            //else if (moons[j].y > moons[k].y)
                            //{
                            //    moons[j].vy--;
                            //    moons[k].vy++;
                            //}
                            //if (moons[j].z < moons[k].z)
                            //{
                            //    moons[j].vz++;
                            //    moons[k].vz--;
                            //}
                            //else if (moons[j].z > moons[k].z)
                            //{
                            //    moons[j].vz--;
                            //    moons[k].vz++;
                            //}
                        }
                    }

                    for (int j = 0; j < moonsCnt; j++)
                    {
                        moonsY[j].y += moonsY[j].vy;
                        //moons[j].y += moons[j].vy;
                        //moons[j].z += moons[j].vz;
                    }

                    bool exact = true;
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        if (/*moons[j].x != moonsLast[j].x*/
                            moonsY[j].y != moonsLastY[j].y 
                            //|| moons[j].z != moonsLast[j].z
                            //|| moons[j].x != moonsStart[j].x
                            || moonsY[j].y != moonsStartY[j].y 
                            //|| moons[j].z != moonsStart[j].z
                            )
                        {
                            exact = false;
                            break;
                        }
                    }

                    if (exact)
                    {
                        int a = 12;
                        y = i;
                        Console.WriteLine(i);
                        break;
                    }

                    //if (i == 4686774924)
                    //{
                    //    Console.WriteLine("nie wykr");
                    //    int a = 12;
                    //    break;
                    //}
                    //int kin = 0;
                    //for (int j = 0; j < moons.Count; j++)
                    //{
                    //    kin += Math.Abs(moons[j].kineticEnergy());
                    //}

                    //if (kin==0)
                    //{
                    //    int a = 12;
                    //}
                    //Console.WriteLine($"After {i} steps:");
                    //foreach (var moon in moons)
                    //{
                    //    Console.WriteLine(moon);
                    //}
                    //Console.WriteLine();

                }

                long z = 0;
                for (long i = 1; i <= maxsteps; i++)
                {
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        //moonsLastZ[j].x = moonsZ[j].x;
                        //moonsLastZ[j].y = moonsZ[j].y;
                        moonsLastZ[j].z = moonsZ[j].z;
                    }
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        for (int k = j; k < moonsCnt; k++)
                        {
                            if (moonsZ[j].z < moonsZ[k].z)
                            {
                                moonsZ[j].vz++;
                                moonsZ[k].vz--;
                            }
                            else if (moonsZ[j].z > moonsZ[k].z)
                            {
                                moonsZ[j].vz--;
                                moonsZ[k].vz++;
                            }
                            //if (moons[j].y < moons[k].y)
                            //{
                            //    moons[j].vy++;
                            //    moons[k].vy--;
                            //}
                            //else if (moons[j].y > moons[k].y)
                            //{
                            //    moons[j].vy--;
                            //    moons[k].vy++;
                            //}
                            //if (moons[j].z < moons[k].z)
                            //{
                            //    moons[j].vz++;
                            //    moons[k].vz--;
                            //}
                            //else if (moons[j].z > moons[k].z)
                            //{
                            //    moons[j].vz--;
                            //    moons[k].vz++;
                            //}
                        }
                    }

                    for (int j = 0; j < moonsCnt; j++)
                    {
                        moonsZ[j].z += moonsZ[j].vz;
                        //moons[j].y += moons[j].vy;
                        //moons[j].z += moons[j].vz;
                    }

                    bool exact = true;
                    for (int j = 0; j < moonsCnt; j++)
                    {
                        if (moonsZ[j].z != moonsLastZ[j].z
                            //|| moons[j].y != moonsLast[j].y 
                            //|| moons[j].z != moonsLast[j].z
                            || moonsZ[j].z != moonsStartZ[j].z
                            //|| moons[j].y != moonsStart[j].y 
                            //|| moons[j].z != moonsStart[j].z
                            )
                        {
                            exact = false;
                            break;
                        }
                    }

                    if (exact)
                    {
                        int a = 12;
                        z = i;
                        Console.WriteLine(i);
                        break;
                    }

                    //if (i == 4686774924)
                    //{
                    //    Console.WriteLine("nie wykr");
                    //    int a = 12;
                    //    break;
                    //}
                    //int kin = 0;
                    //for (int j = 0; j < moons.Count; j++)
                    //{
                    //    kin += Math.Abs(moons[j].kineticEnergy());
                    //}

                    //if (kin==0)
                    //{
                    //    int a = 12;
                    //}
                    //Console.WriteLine($"After {i} steps:");
                    //foreach (var moon in moons)
                    //{
                    //    Console.WriteLine(moon);
                    //}
                    //Console.WriteLine();

                }
                Console.WriteLine(LCM(new long[]{x,y,z}));
                int b = 12;
                //int totalenergy = 0;
                //foreach (var moon in moons)
                //{
                //    totalenergy += moon.totalEnergy();
                //}
                //Console.WriteLine($"totalenergy: {totalenergy}");
            }
            else
            {

            }
        }
        static long LCM(long[] numbers)
        {
            return numbers.Aggregate(lcm);
        }
        static long lcm(long a, long b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }
        static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
