using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_06
{
    class Program
    {
        static void Main(string[] args)
        {
            bool zad1 = false;
            if (zad1)
            {
                var input = File.ReadAllLines("input");
                //var input = "COM)B\r\nB)C\r\nC)D\r\nD)E\r\nE)F\r\nB)G\r\nG)H\r\nD)I\r\nE)J\r\nJ)K\r\nK)L".Split("\r\n").ToList();
                var dist = new Dictionary<string, int>();
                var dist2 = new Dictionary<string, string>();
                int allorb = 0;
                foreach (var line in input)
                {

                    var planets = line.Split(')').ToList();

                    var orb = dist.Where(el => el.Key == planets[0]).ToList();
                    int orbits = 0;
                    if (orb.Count > 0)
                    {
                        var orbi = dist[orb.First().Key];
                        orbits = orbi + 1;
                    }

                    if (planets[0] == "COM")
                    {
                        dist.Add(planets[0], 0);
                        orbits++;
                    }

                    if (orbits == 0)
                    {
                        dist.Add(planets[1], -1);
                        dist2.Add(planets[1], planets[0]);
                    }
                    else
                    {
                        dist.Add(planets[1], orbits);

                    }

                    allorb += orbits;
                }

                while (dist2.Count > 0)
                {
                    var dist3 = dist2;

                    foreach (var elem in dist3.Where(elem => dist.ContainsKey(elem.Value)))
                    {
                        int orbits = dist[elem.Value];
                        if (orbits > -1)
                        {
                            dist[elem.Key] = orbits + 1;
                            dist2.Remove(elem.Key);
                            allorb += orbits + 1;
                        }
                    }
                }

                Console.WriteLine(allorb);
            }
            else
            {
                var input = File.ReadAllLines("input");
                //var input = "COM)B\r\nB)C\r\nC)D\r\nD)E\r\nE)F\r\nB)G\r\nG)H\r\nD)I\r\nE)J\r\nJ)K\r\nK)L\r\nK)YOU\r\nI)SAN".Split("\r\n").ToList();
                //var dist = new Dictionary<string, int>();
                var dist2 = new Dictionary<string, string>();
                string YOUorbit = "";
                string SANorbit = "";
                foreach (var line in input)
                {
                    var planets = line.Split(')').ToList();
                    dist2.Add(planets[1], planets[0]);
                    if (planets[1] == "YOU")
                    {
                        YOUorbit = planets[0];
                    }
                    else if (planets[1] == "SAN")
                    {
                        SANorbit = planets[0];
                    }
                }

                List<string> youToCom = new List<string>() { YOUorbit };
                List<string> sanToCom = new List<string>() { SANorbit };
                while (youToCom.Last() != "COM" || sanToCom.Last() != "COM")
                {
                    if (youToCom.Last() != "COM")
                    {
                        youToCom.Add(dist2[youToCom.Last()]);
                    }
                    if (sanToCom.Last() != "COM")
                    {
                        sanToCom.Add(dist2[sanToCom.Last()]);
                    }
                }

                string firstCommon = "";
                int youDistance = 0;
                for (int i = 0; i < youToCom.Count; i++)
                {
                    if (sanToCom.Contains(youToCom[i]))
                    {
                        firstCommon = youToCom[i];
                        youDistance = i;
                        break;
                    }
                }

                int sanDistance = sanToCom.IndexOf(firstCommon);


                Console.WriteLine(sanDistance + youDistance);
            }
        }
    }
}
