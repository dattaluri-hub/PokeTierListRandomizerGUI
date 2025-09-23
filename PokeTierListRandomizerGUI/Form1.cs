using NAudio.Wave;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PokeTierListRandomizerGUI
{
    public partial class Form1 : Form
    {
        public static List<Pokemon> WildPokemonList { get; set; } = new List<Pokemon>();

        public HttpClient HttpClient = GetHttpClient();

        public Form1()
        {
            InitializeComponent();

            BuildPokemonList();
        }

        private async void catchButton_Click(object sender, EventArgs e)
        {
            NewEncounter();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            NewEncounter();
        }

        private void releaseButton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static async Task PlayOggFileFromUrl(string url)
        {
            using (var httpClient = new HttpClient())
            using (var stream = await httpClient.GetStreamAsync(url))
            using (var vorbisStream = new NAudio.Vorbis.VorbisWaveReader(stream))
            using (var waveOut = new NAudio.Wave.DirectSoundOut())
            {
                waveOut.Init(vorbisStream);
                waveOut.Play();

                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    await Task.Delay(1000);
                }

                waveOut.PlaybackStopped += (sender, e) =>
                {
                    waveOut.Dispose();
                    vorbisStream.Dispose();
                };
            }
        }

        public static HttpClient GetHttpClient()
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            return client;
        }

        private async void BuildPokemonList()
        {
            // Populate the pokemon list with numbers from 1 to 1025 
            for (int i = 1; i <= 1025; i++)
            {
                progressBar1.Value = i;
                WildPokemonList.Add(await GetPokemonFromId(i));
            }

            progressBar1.Hide();
            //Start the first encounter
            NewEncounter();
        }

        public async Task<Pokemon> GetPokemonFromId(int pokeDexId)
        {
            //Get the species data from the pokeapi
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            var speciesJson = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon-species/{pokeDexId}");
            using JsonDocument speciesDocument = JsonDocument.Parse(speciesJson);
            JsonElement speciesRoot = speciesDocument.RootElement;

            string speciesName = speciesRoot.GetProperty("name").ToString().ToUpper();

            // Get the varieties data from the pokeapi
            List<PokemonVariety> varietiesList = new();
            if (speciesRoot.TryGetProperty("varieties", out JsonElement varieties))
            {
                foreach (JsonElement variety in varieties.EnumerateArray())
                {
                    JsonElement pokemonObj = variety.GetProperty("pokemon");
                    string varietyName = pokemonObj.GetProperty("name").GetString().ToUpper();
                    string varietyUrl = pokemonObj.GetProperty("url").GetString();

                    //Get the variety data from the pokeapi
                    var varietyJson = await HttpClient.GetStringAsync(varietyUrl);
                    using JsonDocument varietyDocument = JsonDocument.Parse(varietyJson);
                    JsonElement varietyRoot = varietyDocument.RootElement;

                    //Get Id
                    string varietyId = varietyRoot.GetProperty("id").ToString();
                    
                    // Get cries.latest
                    string? cryUrl = null;
                    if (varietyRoot.TryGetProperty("cries", out JsonElement cries))
                    {
                        cryUrl = cries.GetProperty("latest").GetString();
                    }

                    // Get sprites.other.official-artwork.front_default
                    string? artworkUrl = null;
                    if (varietyRoot.TryGetProperty("sprites", out JsonElement sprites) &&
                        sprites.TryGetProperty("other", out JsonElement other) &&
                        other.TryGetProperty("official-artwork", out JsonElement officialArtwork) &&
                        officialArtwork.TryGetProperty("front_default", out JsonElement frontDefault))
                    {
                        artworkUrl = frontDefault.GetString();
                    }

                    varietiesList.Add(new PokemonVariety
                    {
                        VarietyId = varietyId,
                        VarietyName = varietyName,
                        VarietyImageUrl = artworkUrl,
                        VarietyCryUrl = cryUrl
                    });
                }
            }

            //Return the pokemon object
            return new Pokemon
            {
                PokedexId = pokeDexId,
                SpeciesName = speciesName,
                Forms = varietiesList
            };
        }

        public async Task NewEncounter()
        {
            // Randomly select a pokemon from the list
            var rand = new Random();
            Pokemon pokemonSpecies = WildPokemonList[rand.Next(WildPokemonList.Count())];

            PokemonVariety pokemonEncounter = pokemonSpecies.Forms[rand.Next(pokemonSpecies.Forms.Count())];

            displayMessage.Text = $"A wild {pokemonEncounter.VarietyName} appeared!";

            pokedexNumber.Text = $"#{pokemonSpecies.PokedexId}";

            pokemonImage.Load(pokemonEncounter.VarietyImageUrl);
            PlayOggFileFromUrl(pokemonEncounter.VarietyCryUrl);
        }
    }
}
