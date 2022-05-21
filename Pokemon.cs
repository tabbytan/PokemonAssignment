using System;
using System.Collections.Generic;

namespace PokemonPocket
{
    public class PokemonMaster
    {
        public string Name { get; set; }
        public int NoToEvolve { get; set; }
        public string EvolveTo { get; set; }

        public PokemonMaster(string name, int noToEvolve, string evolveTo)
        {
            this.Name = name;
            this.NoToEvolve = noToEvolve;
            this.EvolveTo = evolveTo;
        }

    }
    public partial class Pokemon
    {
        public string Name { get; set; }
        public int Exp { get; set; }
        public int Hp { get; set; }
        public Pokemon(string name, int exp, int hp)
        {
            this.Name = name;
            this.Exp = exp;
            this.Hp = hp;
        }
        public virtual string Skill()
        {
            return "";
        }
    }













}