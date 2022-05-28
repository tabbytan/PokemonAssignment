namespace PokemonPocket
{
    public partial class Charmander : Pokemon
    {
        public string skill = "Solar Power";
        public Charmander(string name, int exp, int hp) : base(name, exp, hp) { }
        public override string Skill()
        {
            return "Solar Power";
        }
    }
}