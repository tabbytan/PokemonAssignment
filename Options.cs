using System.Collections.Generic;
using System;
using System.Linq;

namespace PokemonPocket

{
    public class Options
    {
        public void option1(List<string> pokemon, MyDbContext pokemonContext)
        {

            int hp_int = -1;
            int exp_int = -1;
            bool setname = false;
            pokemon.Add("pikachu");
            pokemon.Add("eevee");
            pokemon.Add("charmander");


            var name = string.Empty;
            string hp;
            string exp;
            Console.WriteLine("U have reached option1");

            while (!setname)
            {
                Console.WriteLine("Enter PokeMon's Name: ");
                name = Console.ReadLine().ToLower();
                foreach (var p in pokemon)
                {
                    if (name == p)
                    {
                        setname = true;
                        break;

                    }
                }
                if (!setname)
                {
                    Console.WriteLine("This isnt a valid pokemon");
                }

            }
            // do
            // {
            //     Console.WriteLine("Enter Pokemon's HP: ");
            //     hp = Console.ReadLine();

            // } while (!int.TryParse(hp, out hp_int));

            while (hp_int < 0)
            {
                // Console.WriteLine(hp_int);
                Console.WriteLine("Enter Pokemon HP: ");
                hp = Console.ReadLine();
                int output;
                bool result = int.TryParse(hp, out output);
                if (result)
                {
                    hp_int = Convert.ToInt32(hp);
                    {
                        if (hp_int < 0)
                        {
                            Console.WriteLine("Cannot be less than 0");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("this isnt a valid input");
                }
                // Console.WriteLine(hp_int);
            }
            while (exp_int < 0)
            {
                Console.WriteLine("Enter Pokemon EXP: ");
                exp = Console.ReadLine();
                int output;
                bool result = int.TryParse(exp, out output);
                if (result)
                {
                    exp_int = Convert.ToInt32(exp);
                    {
                        if (exp_int < 0)
                        {
                            Console.WriteLine("Cannot be less than 0");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("this isnt a valid input");
                }
            }

            if (name == "pikachu")
            {

                Pikachu pikachu = new Pikachu(name, exp_int, hp_int);
                pokemonContext.Pokemons.Add(pikachu);

                pokemonContext.SaveChanges();


                Console.WriteLine("new Pikachu Has been created");
                Console.WriteLine($"Name:{pikachu.Name} + Exp:{pikachu.Exp} + Hp:{pikachu.Hp}");



            }
            else if (name == "eevee")
            {
                Eevee eevee = new Eevee(name, exp_int, hp_int);
                pokemonContext.Pokemons.Add(eevee);

                pokemonContext.SaveChanges();
                Console.WriteLine("new Eevee Has been created");
                Console.WriteLine($"Name:{eevee.Name} + Exp:{eevee.Exp} + Hp:{eevee.Hp}");
            }
            else if (name == "charmander")
            {
                Charmander charmander = new Charmander(name, exp_int, hp_int);
                pokemonContext.Pokemons.Add(charmander);

                pokemonContext.SaveChanges();
                Console.WriteLine("new Charmander has been created");
                Console.WriteLine($"Name:{charmander.Name} + Exp:{charmander.Exp} + Hp:{charmander.Hp}");
            }



        }
        public void option2(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {
            Console.WriteLine("U have reached option2");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            foreach (var p in pokemonContext.Pokemons.OrderBy(p => p.Hp))
            {
                Console.WriteLine($"Name: {p.Name}\nHealth: {p.Hp}\nExp: {p.Exp} \n{p.Skill()}");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            }

        }
        public void option4(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {

            Console.WriteLine("U have reached option4");
            Console.WriteLine($"pikachu - {pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "pikachu").Count()}\n eevee - {pokemonlist.Where(x => x.Name.ToLower() == "eevee").Count()}\n charmander - {pokemonlist.Where(x => x.Name.ToLower() == "charmander").Count()}");
            foreach (var n in pokemonMasters)
            {
                if (n.Name == "Eevee" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "eevee").Count())
                {
                    // Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");

                    for (int a = 0; a < n.NoToEvolve - 1; a++)
                    {
                        for (int i = 0; i < pokemonContext.Pokemons.Count(); i++)
                        {
                            if (pokemonlist[i].Name == "eevee")
                            {
                                pokemonlist.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < pokemonlist.Count; i++)
                        {
                            if (pokemonlist[i].Name == "eevee")
                            {
                                pokemonlist[i].Name = "Flareon";
                                pokemonlist[i].Exp = 0;
                                pokemonlist[i].Hp = 0;
                            }
                        }
                    }

                }
                if (n.Name == "Pikachu" && n.NoToEvolve <= pokemonlist.Where(x => x.Name.ToLower() == "pikachu").Count())
                {
                    for (int a = 0; a < n.NoToEvolve - 1; a++)
                    {
                        for (int i = 0; i < pokemonlist.Count; i++)
                        {
                            if (pokemonlist[i].Name == "pikachu")
                            {
                                pokemonlist.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < pokemonlist.Count; i++)
                        {
                            if (pokemonlist[i].Name == "pikachu")
                            {
                                pokemonlist[i].Name = "Raichu";
                                pokemonlist[i].Exp = 0;
                                pokemonlist[i].Hp = 0;
                            }
                        }
                    }
                }
                if (n.Name == "Charmander" && n.NoToEvolve <= pokemonlist.Where(x => x.Name.ToLower() == "charmander").Count())
                {
                    for (int a = 0; a < n.NoToEvolve - 1; a++)
                    {
                        for (int i = 0; i < pokemonlist.Count; i++)
                        {
                            if (pokemonlist[i].Name == "charmander")
                            {
                                pokemonlist.RemoveAt(i);
                            }
                        }
                        for (int i = 0; i < pokemonlist.Count; i++)
                        {
                            if (pokemonlist[i].Name == "charmander")
                            {
                                pokemonlist[i].Name = "Charmeleon";
                                pokemonlist[i].Exp = 0;
                                pokemonlist[i].Hp = 0;
                            }
                        }
                    }
                }
            }



        }
        public void option3(List<string> pokemon, List<Pokemon> pokemonlist, List<PokemonMaster> pokemonMasters)
        {
            Console.WriteLine("U have reached option4");
            foreach (var n in pokemonMasters)
            {
                if (n.Name == "Eevee" && n.NoToEvolve <= pokemonlist.Where(x => x.Name.ToLower() == "eevee").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                }
                if (n.Name == "Pikachu" && n.NoToEvolve <= pokemonlist.Where(x => x.Name.ToLower() == "pikachu").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                }
                if (n.Name == "Charmander" && n.NoToEvolve <= pokemonlist.Where(x => x.Name.ToLower() == "charmander").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                }
            }

        }
    }
}