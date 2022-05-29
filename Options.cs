using System.Collections.Generic;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
// Name: Tan Wei Heng
// Admin:201450s
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
            while (!setname)
            {
                Console.WriteLine("Enter PokeMon's Name: ");
                name = Console.ReadLine().ToLower().Trim();
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
                hp = Console.ReadLine().Trim();
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
                exp = Console.ReadLine().Trim();
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

            if (!pokemonContext.Pokemons.Any())
            {
                Console.WriteLine("no pokemon exists go make one");
            }
            else
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                foreach (var p in pokemonContext.Pokemons.OrderBy(p => p.Hp))
                {
                    Console.WriteLine($"{p.PokemonId}.\nName: {p.Name}\nHealth: {p.workingHp}/{p.Hp}\nExp: {p.Exp}\nAttack: {p.Attack} \n{p.Skill()}");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                }
            }

        }
        public void option4(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {

            Console.WriteLine($"pikachu - {pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "pikachu").Count()}\n eevee - {pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "eevee").Count()}\n charmander - {pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "charmander").Count()}");
            foreach (var n in pokemonMasters)
            {
                if (n.Name == "Eevee" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "eevee").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                    var y = pokemonContext.Pokemons.OrderByDescending(x => x.Hp).First(x => x.Name.ToLower() == "eevee");
                    y.Name = "Flareon";
                    y.Exp = 0;
                    y.Hp += (y.Hp / 100) * 20;
                    pokemonContext.Update(y);
                    pokemonContext.SaveChanges();
                    for (int i = 1; i < n.NoToEvolve; i++)
                    {
                        pokemonContext.Remove(pokemonContext.Pokemons.FirstOrDefault(x => x.Name.ToLower() == "eevee"));
                        pokemonContext.SaveChanges();
                    }
                }
                else if (n.Name == "Pikachu" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "pikachu").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                    var y = pokemonContext.Pokemons.OrderByDescending(x => x.Hp).First(x => x.Name.ToLower() == "pikachu");
                    y.Name = "Raichu";
                    y.Exp = 0;
                    y.Hp += (y.Hp / 100) * 20;
                    pokemonContext.Update(y);
                    pokemonContext.SaveChanges();
                    for (int i = 1; i < n.NoToEvolve; i++)
                    {
                        pokemonContext.Remove(pokemonContext.Pokemons.FirstOrDefault(x => x.Name.ToLower() == "pikachu"));
                        pokemonContext.SaveChanges();
                    }
                }
                else if (n.Name == "Charmander" && n.NoToEvolve <= pokemonContext.Pokemons.Where(x => x.Name.ToLower() == "charmander").Count())
                {
                    Console.WriteLine($"{n.Name} ---> {n.EvolveTo}");
                    var y = pokemonContext.Pokemons.OrderByDescending(x => x.Hp).First(x => x.Name.ToLower() == "charmander");
                    y.Name = "Charmeleon";
                    y.Exp = 0;
                    y.Hp += (y.Hp / 100) * 20;
                    pokemonContext.Update(y);
                    pokemonContext.SaveChanges();
                    for (int i = 1; i < n.NoToEvolve; i++)
                    {
                        pokemonContext.Remove(pokemonContext.Pokemons.FirstOrDefault(x => x.Name.ToLower() == "pikachu"));
                        pokemonContext.SaveChanges();
                    }
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
            Potion potion = new Potion(5);
            sortbyid(pokemon, pokemonContext, pokemonMasters);
            if (!pokemonContext.Pokemons.Any())
            {
                Console.WriteLine("no pokemon exists go make one");
            }
            else
            {
                // make random pokemon
                var pokemontype = new Random();
                int randompokemon = pokemontype.Next(1, 3);
                if (randompokemon == 1)
                {
                    Pikachu aipokemon = new Pikachu("AI PIKACHU", 0, pokemontype.Next(3, 5));
                    Console.WriteLine($"FIGHTING {aipokemon.Name}");
                    Pokemon userpokemon = setpokemon(pokemon, pokemonContext, pokemonMasters, aipokemon);
                    fight(aipokemon, userpokemon, pokemonContext, potion);

                }
                else if (randompokemon == 2)
                {
                    Charmander aipokemon = new Charmander("AI CHARMANDER", 0, pokemontype.Next(3, 5));
                    Console.WriteLine($"FIGHTING {aipokemon.Name}");
                    Pokemon userpokemon = setpokemon(pokemon, pokemonContext, pokemonMasters, aipokemon);
                    fight(aipokemon, userpokemon, pokemonContext, potion);


                }
                else if (randompokemon == 3)
                {
                    Eevee aipokemon = new Eevee("AI EEVEE", pokemontype.Next(1, 3), pokemontype.Next(20, 25));
                    Console.WriteLine($"FIGHTING {aipokemon.Name}");
                    Pokemon userpokemon = setpokemon(pokemon, pokemonContext, pokemonMasters, aipokemon);
                    fight(aipokemon, userpokemon, pokemonContext, potion);

                }
            }
        }
        public void wipedatabase(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {
            while (true)
            {
                Console.WriteLine("are you sure this cannot be reversed (y/n)");
                var choice = Console.ReadLine().Trim();
                if (choice.ToString().ToLower() == "y")
                {
                    pokemonContext.RemoveRange(pokemonContext.Pokemons);
                    Console.WriteLine("Database has been wiped");
                    break;
                }
                else if (choice.ToString().ToLower() == "n")
                {
                    break;
                }
            }


        }
        public void deletebyid(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {
            string ans;
            int output;
            while (true)
            {
                try
                {
                    sortbyid(pokemon, pokemonContext, pokemonMasters);
                    do
                    {
                        Console.WriteLine("Enter ID: ");
                        ans = Console.ReadLine().Trim();
                    }
                    while (!int.TryParse(ans, out output));
                    pokemonContext.Remove(pokemonContext.Pokemons.First(x => x.PokemonId == output));
                    Console.WriteLine("your pokemon has been deleted");
                    break;
                }

                catch
                {
                    Console.WriteLine("not in database");
                    break;
                }
            }
        }
        public void sortbyid(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters)
        {
            if (!pokemonContext.Pokemons.Any())
            {
                Console.WriteLine("no pokemon exists go make one");
            }
            else
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                foreach (var p in pokemonContext.Pokemons.OrderBy(p => p.Hp))
                {
                    Console.WriteLine($"{p.PokemonId}.\nName: {p.Name}\nHealth: {p.workingHp}/{p.Hp}\nExp: {p.Exp}\nAttack: {p.Attack} \n{p.Skill()}");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                }
            }

        }
        public void fight(Pokemon aipokemon, Pokemon userpokemon, MyDbContext pokemonContext, Potion potion)
        {

            bool battle = true;
            while (battle == true)
            {
                int choice = 0;
                do
                {
                    choice = choicephase(aipokemon, userpokemon, pokemonContext, potion);
                } while (choice == 0);
                switch (choice)
                {
                    case 1:
                        fightphase(aipokemon, userpokemon, pokemonContext);
                        aifightphase(aipokemon, userpokemon, pokemonContext);
                        battle = checkphase(aipokemon, userpokemon, pokemonContext);
                        break;
                    case 2:
                        aifightphase(aipokemon, userpokemon, pokemonContext);
                        battle = checkphase(aipokemon, userpokemon, pokemonContext);
                        break;
                    case 3:
                        battle = false;
                        break;
                }

            }
            Console.WriteLine("battle is over");

        }

        public int choicephase(Pokemon aipokemon, Pokemon userpokemon, MyDbContext pokemonContext, Potion potion)
        {

            string choice;
            int result;
            bool isValid = true;
            Console.WriteLine($"Enemy Name {aipokemon.Name} ");
            Console.WriteLine($"Enemy Health {aipokemon.workingHp}/{aipokemon.Hp} ");
            Console.WriteLine
            ("what will you do\n(1) Fight \n(2) Use items\n(3) Run Away");
            do
            {
                do
                {
                    Console.WriteLine("Enter Choice: ");
                    choice = Console.ReadLine().Trim();

                } while (!int.TryParse(choice, out result));
                switch (result)
                {

                    case 1:
                        return 1;
                    case 2:
                        if (potion.HpPotion > 0)
                        {
                            potion.HpPotion -= 1;
                            userpokemon.workingHp += 10;
                            if (userpokemon.workingHp > userpokemon.Hp)
                            {
                                userpokemon.workingHp = userpokemon.Hp;
                            }
                            Console.WriteLine($"you have used an potion +10hp {potion.HpPotion} potions left");
                            Console.WriteLine($"{userpokemon.Name} has {userpokemon.workingHp}/{userpokemon.Hp}hp left");
                        }
                        else
                        {

                            Console.WriteLine($"you tried to use a potion but u had none left! {aipokemon.Name} attacks!");
                        }
                        return 2;
                    case 3:
                        Console.WriteLine("you have run away");
                        return 3;
                    default:
                        Console.WriteLine("Invalid Choice");
                        return 0;
                }
            }
            while (isValid);
        }

        public void aifightphase(Pokemon aipokemon, Pokemon userpokemon, MyDbContext pokemonContext)
        {
            Console.WriteLine($"{aipokemon.Name} Attacks");
            userpokemon.workingHp -= aipokemon.Attack;
            Console.WriteLine($"{userpokemon.Name} has {userpokemon.workingHp}/{userpokemon.Hp}hp left");
        }
        public void fightphase(Pokemon aipokemon, Pokemon userpokemon, MyDbContext pokemonContext)
        {
            aipokemon.workingHp -= userpokemon.Attack;
            Console.WriteLine($"{aipokemon.Name} has {aipokemon.workingHp}/{aipokemon.Hp}hp left");
        }
        public bool checkphase(Pokemon aipokemon, Pokemon userpokemon, MyDbContext pokemonContext)
        {
            // battle loop
            {
                if (aipokemon.workingHp <= 0)
                {
                    aipokemon.workingHp = 0;
                    Console.WriteLine("Your Pokemon won! \nExp given +2 \n");
                    userpokemon.Exp += 2;
                    pokemonContext.Update(userpokemon);
                    pokemonContext.SaveChanges();
                    Console.WriteLine($"{userpokemon.Name} has {userpokemon.workingHp}/{userpokemon.Hp}hp left");
                    while (true)
                    {
                        Console.WriteLine("do you wish to go to a pokecentre to heal? (y/n)");
                        var choice = Console.ReadLine().Trim();
                        if (choice.ToString().ToLower() == "y")
                        {
                            Console.WriteLine("your pokemon is healed to full hp");
                            userpokemon.workingHp = userpokemon.Hp;
                            pokemonContext.Update(userpokemon);
                            pokemonContext.SaveChanges();
                            return false;

                        }
                        else if (choice.ToString().ToLower() == "n")
                        {
                            return false;
                        }
                    }
                }
                if (userpokemon.workingHp <= 0)
                {
                    Console.WriteLine("your pokemon has fainted you rushed to a pokemon centre to heal them");
                    userpokemon.workingHp = userpokemon.Hp;
                    Console.WriteLine($"Your Pokemon Hp:{userpokemon.workingHp}");
                }
                return true;





            }
        }
        public Pokemon setpokemon(List<string> pokemon, MyDbContext pokemonContext, List<PokemonMaster> pokemonMasters, Pokemon aipokemon)
        {
            string ans;
            int output;
            while (true)
                try
                {

                    Console.WriteLine("find which pokemon to use in battle by ID");
                    do
                    {
                        Console.WriteLine("Enter ID: ");
                        ans = Console.ReadLine().Trim();
                    }
                    while (!int.TryParse(ans, out output));
                    Pokemon userpokemon = pokemonContext.Pokemons.Single(x => x.PokemonId == output);
                    Console.WriteLine("your pokemon has been set");
                    return userpokemon;
                }
                catch
                {
                    Console.WriteLine("not in database");
                }
        }

    }
}
