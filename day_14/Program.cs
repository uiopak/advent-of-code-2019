using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace day_14
{
    class Program
    {
        class Chemical
        {
            public string name;
            public int quantity;

            public Chemical(string s, int i)
            {
                name = s;
                quantity = i;
            }
        }

        class Reaction
        {
            public List<Chemical> inputs;
            public Chemical output;

            public Reaction(List<Chemical> i, Chemical o)
            {
                inputs = i;
                output = o;
            }
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var input = File.ReadAllLines("input");
            List<Reaction> reactions = new List<Reaction>();
            Reaction reaction = null;
            Reaction reaction2 = null;
            foreach (var s1 in input)
            {

                var s = s1.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                List<Chemical> chemicals = new List<Chemical>();
                foreach (var s2 in s[0].Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    var strings = s2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    chemicals.Add(new Chemical(strings[1], int.Parse(strings[0])));
                }

                var split = s[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (split[1].Equals("FUEL"))
                {
                    reaction = new Reaction(chemicals, new Chemical(split[1], int.Parse(split[0])));
                    reaction2 = new Reaction(chemicals, new Chemical(split[1], int.Parse(split[0])));
                }
                else
                {
                    reactions.Add(new Reaction(chemicals, new Chemical(split[1], int.Parse(split[0]))));
                }
            }
            List<Chemical> wastedChemicals = new List<Chemical>();
            bool lastNoReactions = false;
            while (reaction.inputs.Count > 1)
            {
                bool wasLastNoReactions = lastNoReactions;
                lastNoReactions = true;
                var inp = reaction.inputs.ToList();
                List<Chemical> newInput = new List<Chemical>();
                //var lastOre = inp.FirstOrDefault(el => el.name == "ORE");
                //if (lastOre!=null)
                //{
                //    newInput.Add(lastOre);
                //}
                foreach (var chemical in inp)
                {
                    //var reactions2 = reactions.ConvertAll(react =>
                    //    new Reaction(react.inputs.ConvertAll(chem => new Chemical(chem.name, chem.quantity)),
                    //        new Chemical(react.output.name, react.output.quantity)));
                    var find2 = reactions.FirstOrDefault(el => el.output.name == chemical.name);
                    var find = new Reaction(find2.inputs.ConvertAll(chem=>new Chemical(chem.name,chem.quantity)),new Chemical(find2.output.name,find2.output.quantity));
                    if (find != null && find.inputs[0].name != "ORE" || find != null && (find.inputs[0].name == "ORE" && wasLastNoReactions))
                    {
                        if (wasLastNoReactions)
                        {
                            int a1 = 12;
                        }
                        lastNoReactions = false;
                        var findChemical = wastedChemicals.FirstOrDefault(el => el.name == chemical.name);
                        if (findChemical != null)
                        {
                            int dif = chemical.quantity > findChemical.quantity
                                ? findChemical.quantity
                                : chemical.quantity;
                            chemical.quantity -= dif;
                            if (chemical.quantity > findChemical.quantity)
                            {
                                wastedChemicals.Remove(findChemical);
                            }
                            else
                            {
                                findChemical.quantity -= dif;
                            }
                        }
                        int multiplier = (int)Math.Ceiling((double)chemical.quantity / (double)find.output.quantity);
                        int waste = multiplier * find.output.quantity - chemical.quantity;
                        if (find.inputs[0].name == "ORE")
                        {
                            Console.WriteLine($"create {multiplier * find.output.quantity} {find.output.name} using {find.inputs[0].quantity*multiplier} ORE");
                        }
                        if (waste > 0)//pomysł żeby policzyć ile nie trzeba było marnować ale to nie jest optymalne
                        {
                            var findChemical2 = wastedChemicals.FirstOrDefault(el => el.name == chemical.name);
                            if (findChemical2 != null)
                            {
                                findChemical2.quantity += waste;
                            }
                            else
                            {
                                wastedChemicals.Add(new Chemical(chemical.name, waste));
                            }

                        }
                        //todo count how many to produce
                        foreach (var findInput in find.inputs)
                        {
                            if (findInput.name== "NVRVD")
                            {
                                int a2 = 12;
                            }
                            if (newInput.Exists(el => el.name == findInput.name))
                            {
                                newInput.Find(el => el.name == findInput.name).quantity += (findInput.quantity * multiplier);
                            }
                            else
                            {
                                findInput.quantity *= multiplier;
                                newInput.Add(findInput);
                            }
                        }
                    }
                    else
                    {
                        if (chemical.name == "NVRVD")
                        {
                            int a2 = 12;
                        }
                        if (newInput.Exists(el => el.name == chemical.name))
                        {
                            newInput.Find(el => el.name == chemical.name).quantity += chemical.quantity;
                        }
                        else
                        {
                            newInput.Add(chemical);
                        }
                    }
                }
                //policz ile trzeba razy robić każdy chemical i połącz ich składniki, zamień w reaction robić aż zostanie tylko ore
                int a = 12;
                reaction.inputs = newInput;
            }

            long usedOre = reaction.inputs[0].quantity;
            int boost = 500000;
            var fuel = boost;
            usedOre *= boost;
            long lastUsedOre = usedOre;
            wastedChemicals.ForEach(chem=> chem.quantity *= boost);
            while (usedOre< 1000000000000)
            {
                lastUsedOre = usedOre;
                lastNoReactions = false;
                reaction = new Reaction(reaction2.inputs.ConvertAll(chem=> new Chemical(chem.name,chem.quantity)),new Chemical(reaction2.output.name,reaction2.output.quantity));

                while (reaction.inputs.Count > 1)
                {
                    bool wasLastNoReactions = lastNoReactions;
                    lastNoReactions = true;
                    var inp = reaction.inputs.ToList();
                    List<Chemical> newInput = new List<Chemical>();
                    foreach (var chemical in inp)
                    {
                        //var reactions2 = reactions.ConvertAll(react =>
                        //    new Reaction(react.inputs.ConvertAll(chem => new Chemical(chem.name, chem.quantity)),
                        //        new Chemical(react.output.name, react.output.quantity)));
                        var find2 = reactions.FirstOrDefault(el => el.output.name == chemical.name);
                        var find = new Reaction(find2.inputs.ConvertAll(chem => new Chemical(chem.name, chem.quantity)), new Chemical(find2.output.name, find2.output.quantity));
                        if (find != null && find.inputs[0].name != "ORE" || find != null && (find.inputs[0].name == "ORE" && wasLastNoReactions))
                        {
                            if (wasLastNoReactions)
                            {
                                int a1 = 12;
                            }
                            lastNoReactions = false;
                            var findChemical = wastedChemicals.FirstOrDefault(el => el.name == chemical.name);
                            if (findChemical != null)
                            {
                                int dif = chemical.quantity > findChemical.quantity
                                    ? findChemical.quantity
                                    : chemical.quantity;
                                chemical.quantity -= dif;
                                if (chemical.quantity > findChemical.quantity)
                                {
                                    wastedChemicals.Remove(findChemical);
                                }
                                else
                                {
                                    findChemical.quantity -= dif;
                                }
                            }
                            int multiplier = (int)Math.Ceiling((double)chemical.quantity / (double)find.output.quantity);
                            int waste = multiplier * find.output.quantity - chemical.quantity;
                            if (waste > 0)//pomysł żeby policzyć ile nie trzeba było marnować ale to nie jest optymalne
                            {
                                var findChemical2 = wastedChemicals.FirstOrDefault(el => el.name == chemical.name);
                                if (findChemical2 != null)
                                {
                                    findChemical2.quantity += waste;
                                }
                                else
                                {
                                    wastedChemicals.Add(new Chemical(chemical.name, waste));
                                }

                            }
                            //todo count how many to produce
                            foreach (var findInput in find.inputs)
                            {
                                if (findInput.name == "NVRVD")
                                {
                                    int a2 = 12;
                                }
                                if (newInput.Exists(el => el.name == findInput.name))
                                {
                                    newInput.Find(el => el.name == findInput.name).quantity += (findInput.quantity * multiplier);
                                }
                                else
                                {
                                    findInput.quantity *= multiplier;
                                    newInput.Add(findInput);
                                }
                            }
                        }
                        else
                        {
                            if (chemical.name == "NVRVD")
                            {
                                int a2 = 12;
                            }
                            if (newInput.Exists(el => el.name == chemical.name))
                            {
                                newInput.Find(el => el.name == chemical.name).quantity += chemical.quantity;
                            }
                            else
                            {
                                newInput.Add(chemical);
                            }
                        }
                    }
                    //policz ile trzeba razy robić każdy chemical i połącz ich składniki, zamień w reaction robić aż zostanie tylko ore
                    int a = 12;
                    reaction.inputs = newInput;
                }

                usedOre += reaction.inputs[0].quantity;
                fuel++;
                if (lastUsedOre!=usedOre)
                {
                     int a3 = 12;
                }
            }

            Console.WriteLine(fuel-1);
        }
    }
}
