using System;
using System.Collections.Generic;

namespace PokemonPocket
{
    public partial class Pikachu : Pokemon
    {
        public Pikachu(string name, int exp, int hp) : base(name, exp, hp) { }
        public override string Skill()
        {
            return "Lightning bolt";
        }
    }
}