using System;
using System.Collections.Generic;
using System.Linq;
// Tan wei heng 201450s
namespace PokemonPocket
{
    class Program
    {
        static List<Pokemon> pokemonlist = new List<Pokemon>();
        static void option1()
        {
            int hp_int = -1;
            int exp_int = -1;
            bool setname = false;
            var pokemon = new List<string>();
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

                Pikachu Pikachu = new Pikachu(name, exp_int, hp_int);
                Console.WriteLine("new Pikachu Has been created");
                Console.WriteLine(Pikachu.Name + Pikachu.Exp + Pikachu.Hp);
                pokemonlist.Add(Pikachu);


            }
            else if (name == "eevee")
            {
                Eevee Eevee = new Eevee(name, exp_int, hp_int);
                Console.WriteLine("new Eevee Has been created");
                Console.WriteLine(Eevee.Name + Eevee.Exp + Eevee.Hp);
                pokemonlist.Add(Eevee);
            }
            else if (name == "charmander")
            {
                Charmander Charmander = new Charmander(name, exp_int, hp_int);
                Console.WriteLine("new Charmander has been created");
                Console.WriteLine(Charmander.Name + Charmander.Exp + Charmander.Hp);
                pokemonlist.Add(Charmander);
            }



        }
        static void option2()
        {
            Console.WriteLine("U have reached option2");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            foreach (var p in pokemonlist.OrderBy(p => p.Hp))
            {
                Console.WriteLine($"Name: {p.Name}\nHealth: {p.Hp}\nExp: {p.Exp} ");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            }

        }
        static void option3()
        {
            Console.WriteLine("U have reached option3");
        }
        static void option4()
        {
            Console.WriteLine("U have reached option4");
        }
        static void Main(string[] args)
        {

            //PokemonMaster list for checking pokemon evolution availability.    
            List<PokemonMaster> pokemonMasters = new List<PokemonMaster>(){
            new PokemonMaster("Pikachu", 2, "Raichu"),
            new PokemonMaster("Eevee", 3, "Flareon"),
            new PokemonMaster("Charmander", 1, "Charmeleon")
            };
            //Use "Environment.Exit(0);" if you want to implement an exit of the console program
            //Start your assignment 1 requirements below.
            bool mainmenuloop = true;
            while (mainmenuloop)
            {

                Console.WriteLine("***************************************************\nWelcome to pokemon pocket App\n***************************************************");
                Console.WriteLine("(1)Add Pokemon to my pocket");
                Console.WriteLine("(2)List pokemon(s) in my pocket");
                Console.WriteLine("(3)Check if i can evolve pokemon");
                Console.WriteLine("(4)evolve pokemon");
                Console.Write("Please only enter [1,2,3,4] or Q to quit: ");
                var input = Console.ReadLine().Trim();
                if (input == "1")
                {

                    option1();
                }
                else if (input == "2")
                {

                    option2();
                }
                else if (input == "3")
                {

                    option3();
                }
                else if (input == "4")
                {

                    option4();
                }
                else if (input.ToLower() == "q")
                {

                    Environment.Exit(0);
                    Console.Clear();
                }

            }





        }
    }
}
