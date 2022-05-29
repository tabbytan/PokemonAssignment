// Name: Tan Wei Heng
// Admin:201450s
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