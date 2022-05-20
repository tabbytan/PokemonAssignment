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
    public class Pokemon
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
    }
    public class Pikachu : Pokemon
    {
        public string skill = "Lightning bolt";
        public Pikachu(string name, int exp, int hp) : base(name, exp, hp) { }
    }










}