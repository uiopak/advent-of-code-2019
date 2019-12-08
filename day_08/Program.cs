using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_08
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input");
            //var input = "0222112222120000";
            bool part_one = true;
            const int width = 25;
            const int height = 6;
            //const int width = 2;
            //const int height = 2;
            if (part_one)
            {
                int read = 0;
                int length = input.Length;
                List< List < List<char> >> layers = new List<List<List<char>>>();
                List<Tuple<int,int,int>> layers2 =new List<Tuple<int, int, int>>();
                while (read<input.Length-1)
                {
                    List<List<char>> layer = new List<List<char>>();
                    int i0 = 0;
                    int i1 = 0;
                    int i2 = 0;
                    for (int i = 0; i < height; i++)
                    {

                        layer.Add(input.Substring(read + i * width, width).ToList());
                        i0 += layer.Last().Count(f=> f=='0');
                        i1 += layer.Last().Count(f=> f=='1');
                        i2 += layer.Last().Count(f=> f=='2');


                    }
                    layers.Add(layer);
                    layers2.Add(new Tuple<int, int, int>(i0,i1,i2));
                    read += height * width;
                }

                var asd = layers2.Where(el=> el.Item1== layers2.Min(l => l.Item1));
                char[,] image = new char[height, width]
                //{
                //    {'2', '2'},
                //    {'2', '2'}
                //};
                {
                    {'2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2' }
                    ,{'2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2' }
                    ,{'2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2' }
                    ,{'2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2' }
                    ,{'2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2' },
                    {'2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2' }
                };
                layers.Reverse();
                foreach (var layer in layers)
                {
                    int rowi = 0;
                    foreach (var row in layer)
                    {
                        int pixel = 0;
                        foreach (var c in row)
                        {
                            if (c != '2')
                            {
                                image[rowi,pixel ] = c;
                            }
                            pixel++;
                        }
                        rowi++;
                    }
                }

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (image[i,j]=='1')
                        {
                            Console.Write("\u2588");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        //Console.Write(image[i,j]);
                    }
                    Console.Write("\n");
                }
            Console.WriteLine(asd.First().Item2*asd.First().Item3);
            }
            else
            {

            }

        }
    }
}
