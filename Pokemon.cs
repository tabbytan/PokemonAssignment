using System;
using System.Collections.Generic;
using System.Threading;

namespace PokemonPocket
{

    public class PokemonMaster
    {
        public virtual string Name { get; set; }
        public virtual int NoToEvolve { get; set; }
        public virtual string EvolveTo { get; set; }

        public PokemonMaster(string name, int noToEvolve, string evolveTo)
        {
            this.Name = name;
            this.NoToEvolve = noToEvolve;
            this.EvolveTo = evolveTo;
        }

    }

    public partial class Pokemon
    {
        public virtual int PokemonId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Hp { get; set; }
        public virtual int Exp { get; set; }
        public virtual int workingHp { get; set; }
        public virtual int Attack { get; set; }


        public Pokemon(string name, int exp, int hp)

        {
            this.Name = name;
            this.Exp = exp;
            this.Hp = hp;
            this.workingHp = hp;
            this.Attack = 2 + (Exp / 5);
            if (Hp == 0)
            {
                Hp = 1;
            }


        }
        public virtual string Skill()
        {
            return "";
        }
    }



}













