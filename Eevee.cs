namespace PokemonPocket
{
    public class Eevee : Pokemon
    {
        public string skill = "Run Away";
        public Eevee(string name, int exp, int hp) : base(name, exp, hp) { }
        public override string Skill()
        {
            return "Run Away";
        }
    }
}