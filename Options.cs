using System.Collections.Generic;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace PokemonPocket

{
    public class Options
    {
        public void option1(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
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
                Console.WriteLine($"{p.PokemonId}.\nName: {p.Name}\nHealth: {p.workingHp}/{p.Hp}\nExp: {p.Exp}\nAttack: {p.Attack} \n{p.Skill()}");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            }

        }
        public void option4(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {

            Console.WriteLine("U have reached option4");
            Console.WriteLine($"pikachu - {pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "pikachu").Count()}\n eevee - {pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "eevee").Count()}\n charmander - {pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "charmander").Count()}");
            foreach (var n in pokemonMasters)
            {
                if (n.Name == "Eevee" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "eevee").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                    var y = pokemonContext.Pokemons.First(x => x.Name.ToLower() == "eevee");
                    y.Name = "Flareon";
                    y.Exp = 0;
                    y.Hp = 0;
                    pokemonContext.Update(y);
                    pokemonContext.SaveChanges();
                    for (int i = 0; i < n.NoToEvolve; i++)
                    {
                        pokemonContext.Remove(pokemonContext.Pokemons.First(x => x.Name.ToLower() == "eevee"));
                    }
                    pokemonContext.SaveChanges();
                }
                else if (n.Name == "Pikachu" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "pikachu").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                    var y = pokemonContext.Pokemons.First(x => x.Name.ToLower() == "pikachu");
                    y.Name = "Raichu";
                    y.Exp = 0;
                    y.Hp = 0;
                    pokemonContext.Update(y);
                    pokemonContext.SaveChanges();
                    for (int i = 0; i < n.NoToEvolve; i++)
                    {
                        pokemonContext.Remove(pokemonContext.Pokemons.First(x => x.Name.ToLower() == "pikachu"));
                    }
                    pokemonContext.SaveChanges();
                }
                else if (n.Name == "Pikachu" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "charmander").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                    var y = pokemonContext.Pokemons.First(x => x.Name.ToLower() == "charmander");
                    y.Name = "Charmeleon";
                    y.Exp = 0;
                    y.Hp = 0;
                    pokemonContext.Update(y);
                    pokemonContext.SaveChanges();
                    for (int i = 0; i < n.NoToEvolve; i++)
                    {
                        pokemonContext.Remove(pokemonContext.Pokemons.First(x => x.Name.ToLower() == "charmander"));
                    }
                    pokemonContext.SaveChanges();
                }
                //         if (n.Name == "Pikachu" && n.NoToEvolve <= pokemonlist.Where(x => x.Name.ToLower() == "pikachu").Count())
                //         {
                //             for (int a = 0; a < n.NoToEvolve - 1; a++)
                //             {
                //                 for (int i = 0; i < pokemonlist.Count; i++)
                //                 {
                //                     if (pokemonlist[i].Name == "pikachu")
                //                     {
                //                         pokemonlist.RemoveAt(i);
                //                     }
                //                 }
                //                 for (int i = 0; i < pokemonlist.Count; i++)
                //                 {
                //                     if (pokemonlist[i].Name == "pikachu")
                //                     {
                //                         pokemonlist[i].Name = "Raichu";
                //                         pokemonlist[i].Exp = 0;
                //                         pokemonlist[i].Hp = 0;
                //                     }
                //                 }
                //             }
                //         }
                //         if (n.Name == "Charmander" && n.NoToEvolve <= pokemonlist.Where(x => x.Name.ToLower() == "charmander").Count())
                //         {
                //             for (int a = 0; a < n.NoToEvolve - 1; a++)
                //             {
                //                 for (int i = 0; i < pokemonlist.Count; i++)
                //                 {
                //                     if (pokemonlist[i].Name == "charmander")
                //                     {
                //                         pokemonlist.RemoveAt(i);
                //                     }
                //                 }
                //                 for (int i = 0; i < pokemonlist.Count; i++)
                //                 {
                //                     if (pokemonlist[i].Name == "charmander")
                //                     {
                //                         pokemonlist[i].Name = "Charmeleon";
                //                         pokemonlist[i].Exp = 0;
                //                         pokemonlist[i].Hp = 0;
                //                     }
                //                 }
                //             }
                //         }
                //     }
                // 
            }
        }


        public void option3(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {
            Console.WriteLine("U have reached option4");
            foreach (var n in pokemonMasters)
            {
                if (n.Name == "Eevee" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "eevee").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                }
                if (n.Name == "Pikachu" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "pikachu").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                }
                if (n.Name == "Charmander" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "charmander").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                }
            }
        }
        public virtual void option5(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {
            List<object> aipokemonlist = new List<object>();
            Console.WriteLine("you have reached option5");
            var pokemontype = new Random();
            // int randompokemon = pokemontype.Next(1, 3);
            int randompokemon = 3;
            if (randompokemon == 1)
            {
                Pikachu aipokemon = new Pikachu("AI PIKACHU", 0, pokemontype.Next(3, 5));
                Console.WriteLine($"FIGHTING {aipokemon.Name}");
                aipokemonlist.Append(aipokemon);

            }
            else if (randompokemon == 2)
            {
                Charmander aipokemon = new Charmander("AI CHARMANDER", 0, pokemontype.Next(3, 5));
                Console.WriteLine($"FIGHTING {aipokemon.Name}");
                aipokemonlist.Append(aipokemon);

            }
            else if (randompokemon == 3)
            {
                Eevee aipokemon = new Eevee("AI EEVEE", pokemontype.Next(1, 3), pokemontype.Next(20, 25));
                Console.WriteLine($"FIGHTING {aipokemon.Name}");
                int idinput = -1;
                while (idinput < 0)
                {
                    try
                    {
                        option2(pokemon, pokemonContext, pokemonMasters);
                        Console.WriteLine("find which pokemon to use in battle by ID");
                        var ans = Console.ReadLine();
                        int output;
                        bool result = int.TryParse(ans, out output);
                        if (result)
                        {
                            idinput = Convert.ToInt32(ans);
                            {
                                if (idinput < 0)
                                {
                                    Console.WriteLine("Cannot be less than 0");
                                }
                            }
                            object fightpokemon = pokemonContext.Pokemons.Single(x => x.PokemonId == idinput);
                            Console.WriteLine("your pokemon has been set");
                        }
                        else
                        {
                            Console.WriteLine("this isnt a valid input");
                        }
                    }
                    catch
                    {
                        idinput = -1;
                        Console.WriteLine("not in database");
                    }
                }
                bool useraction = true;
                while (useraction)
                {
                    Console.WriteLine($"Enemy Name {aipokemon.Name} ");
                    Console.WriteLine($"Enemy Health {aipokemon.workingHp}/{aipokemon.workingHp} ");
                    Console.WriteLine
                    ("what will you do\n(1) Fight \n(2) Use items\n(3) Run Away");
                    int choice = -1;
                    while (choice < 0 || choice > 3)
                    {
                        Console.WriteLine("Choice: ");
                        var ans = Console.ReadLine();
                        int output;
                        bool result = int.TryParse(ans, out output);
                        if (result)
                        {
                            choice = Convert.ToInt32(ans);
                            {
                                if (choice < 0)
                                {
                                    Console.WriteLine("Cannot be less than 0");
                                }
                                else if (choice > 3)
                                {
                                    Console.WriteLine("cant be bigger than 3");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("this isnt a valid input");
                        }
                    }
                    switch (choice)
                    {

                        case 1:
                            aipokemon.workingHp -= aipokemon.Attack;
                            Console.Write($"{aipokemon.Name} has {aipokemon.workingHp} left");
                            useraction = false;
                            break;

                        case 2:
                            useraction = false;
                            break;

                        case 3:
                            useraction = false;
                            Console.WriteLine("you have run away");
                            break;

                        default:
                            break;
                    }
                }
            }


        }



    }
}