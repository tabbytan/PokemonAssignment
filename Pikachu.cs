using System;
using System.Collections.Generic;

namespace PokemonPocket
{
    public class Pikachu : Pokemon
    {
        public string skill = "Lightning bolt";
        public Pikachu(string name, int exp, int hp) : base(name, exp, hp) { }
    }
}