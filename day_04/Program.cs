using System;

namespace day_04
{
    class Program
    {
        static void Main(string[] args)
        {
            bool part_one = false;
            int min = 264360;
            int max = 746325;
            int cnt = 0;
            for (int i = min; i <= max; i++)
            {
                int d1 = i % 10;
                int d2 = (i / 10) % 10;
                int d3 = (i / 100) % 10;
                int d4 = (i / 1000) % 10;
                int d5 = (i / 10000) % 10;
                int d6 = (i / 100000) % 10;
                if (d6 <= d5 && d5 <= d4 && d4 <= d3 && d3 <= d2 && d2 <= d1)
                {
                    if (part_one)
                    {
                        if (d1 == d2 || d2 == d3 || d3 == d4 || d4 == d5 || d5 == d6)
                        {
                            cnt++;
                        }
                    }
                    else
                    {
                        if ((d1 == d2 && d3 != d2) || (d2 == d3 && d3 != d4 && d1 != d2) || (d3 == d4 && d3 != d2 && d5 != d4) || (d4 == d5 && d3 != d4 && d5 != d6) || (d5 == d6 && d4 != d5))
                        {
                            cnt++;
                        }
                    }
                }
            }
            Console.WriteLine($"{cnt}");
        }
    }
}

