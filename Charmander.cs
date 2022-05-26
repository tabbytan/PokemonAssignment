namespace PokemonPocket
{
    public class Charmander : Pokemon
    {

        public Charmander(string name, int exp, int hp) : base(name, exp, hp) { }
        public override string Skill()
        {
            return "Solar Power";
        }
    }
}