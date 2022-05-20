using System;
using System.Collections.Generic;
using System.Linq;
// Tan wei heng 201450s
namespace PokemonPocket
{
    class Program
    {
        static void option1()
        {
            int hp_int = -1;
            bool setname = false;
            var pokemon = new List<string>();
            pokemon.Add("pikachu");
            pokemon.Add("eevee");
            pokemon.Add("charmander");
            var name = string.Empty;
            string hp;
            Console.WriteLine("U have reached option1");

            while (!setname)
            {
                Console.WriteLine("Enter PokeMon's Name: ");
                name = Console.ReadLine();
                foreach (var p in pokemon)
                {
                    if (name == p)
                    {
                        setname = true;
                    }
                }
            }
            // do
            // {
            //     Console.WriteLine("Enter Pokemon's HP: ");
            //     hp = Console.ReadLine();

            // } while (!int.TryParse(hp, out hp_int));

            while (hp_int < 0)
            {
                Console.WriteLine("Enter Pokemon HP: ");
                hp = Console.ReadLine();
                int.TryParse(hp, out hp_int);
            }



        }
        static void option2()
        {
            Console.WriteLine("U have reached option2");
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
                    mainmenuloop = false;
                    option1();
                }
                else if (input == "2")
                {
                    mainmenuloop = false;
                    option2();
                }
                else if (input == "3")
                {
                    mainmenuloop = false;
                    option3();
                }
                else if (input == "4")
                {
                    mainmenuloop = false;
                    option4();
                }
                else if (input.ToLower() == "q")
                {
                    mainmenuloop = false;
                    Environment.Exit(0);
                    Console.Clear();
                }

            }





        }
    }
}
