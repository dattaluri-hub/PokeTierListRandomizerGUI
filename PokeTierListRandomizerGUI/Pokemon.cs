namespace PokeTierListRandomizerGUI
{
    public class Pokemon
    {
        public int PokedexId { get; set; }

        public string? SpeciesName { get; set; }

        public List<PokemonVariety>? Forms { get; set; }
    }

    public class PokemonVariety
    {
        public string? VarietyId { get; set; }
        public string? VarietyName { get; set; }
        public string? VarietyImageUrl { get; set; }
        public string? VarietyCryUrl { get; set; } 
    }
}
