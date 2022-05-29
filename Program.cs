using System;
using System.Collections.Generic;
using System.Linq;
// Name: Tan Wei Heng
// Admin:201450s
namespace PokemonPocket
{
    class Program
    {


        static void Main(string[] args)
        {
            Options options = new Options();
            MyDbContext pokemonContext = new MyDbContext();
            List<Pokemon> pokemonlist = pokemonContext.Pokemons.ToList();
            List<string> pokemon = new List<string>();
            List<PokemonMaster> pokemonMasters = new List<PokemonMaster>(){
            new PokemonMaster("Pikachu", 2, "Raichu"),
            new PokemonMaster("Eevee", 3, "Flareon"),
            new PokemonMaster("Charmander", 1, "Charmeleon")
            };
            //PokemonMaster list for checking pokemon evolution availability.    

            //Use "Environment.Exit(0);" if you want to implement an exit of the console program
            //Start your assignment 1 requirements below.
            bool mainmenuloop = true;
            while (mainmenuloop)
            {

                Console.WriteLine("***************************************************\nWelcome to pokemon pocket App\n***************************************************");
                Console.WriteLine("(1)Add Pokemon to my pocket");
                Console.WriteLine("(2)List pokemon(s) in my pocket by HP");
                Console.WriteLine("(3)Check if i can evolve pokemon");
                Console.WriteLine("(4)evolve pokemon");
                Console.WriteLine("(5)Enter AI fight");
                Console.WriteLine("(6)Wipe all pokemon");
                Console.WriteLine("(7)Wipe by id");

                Console.Write("Please only enter [1,2,3,4,5,6,7] or Q to quit: ");
                var input = Console.ReadLine().Trim();

                if (input == "1")
                {

                    options.option1(pokemon, pokemonContext, pokemonMasters);
                }
                else if (input == "2")
                {
                    options.option2(pokemon, pokemonContext, pokemonMasters);
                }
                else if (input == "3")
                {

                    options.option3(pokemon, pokemonContext, pokemonMasters);
                }
                else if (input == "4")
                {

                    options.option4(pokemon, pokemonContext, pokemonMasters);
                }
                else if (input == "5")
                {
                    options.option5(pokemon, pokemonContext, pokemonMasters);
                }
                else if (input == "6")
                {
                    options.wipedatabase(pokemon, pokemonContext, pokemonMasters);
                    pokemonContext.SaveChanges();
                }
                else if (input == "7")
                {
                    options.deletebyid(pokemon, pokemonContext, pokemonMasters);
                    pokemonContext.SaveChanges();
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