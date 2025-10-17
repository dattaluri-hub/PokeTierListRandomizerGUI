using NAudio.Wave;
using System.Diagnostics.Eventing.Reader;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PokeTierListRandomizerGUI
{
    public partial class Form1 : Form
    {
        public static List<Pokemon> WildPokemonList { get; set; } = new List<Pokemon>();

        public static List<Pokemon> CaughtPokemonList { get; set; } = new List<Pokemon>();

        public HttpClient HttpClient = GetHttpClient();

        public int CountdownValue = 60;

        public int? EncounterId;

        public string? EncounterVarietyId;

        public Form1()
        {
            InitializeComponent();

            BuildPokemonList();
        }

        private async void catchButton_Click(object sender, EventArgs e)
        {
            //Check if there is an encounter
            if (EncounterId == null || EncounterVarietyId == null)
            { 
                NewEncounter();
                return;
            }

            //Remove the encounter from the list
            var pokemonToRemove = WildPokemonList.FirstOrDefault(p => p.PokedexId == EncounterId);
            var pokemonFormToRemove = pokemonToRemove.Forms.First(f => f.VarietyId == EncounterVarietyId);

            if (pokemonToRemove != null && pokemonFormToRemove != null)
            {
                //Add to caught list
                if (CaughtPokemonList.Any(p => p.PokedexId == EncounterId))
                {
                    CaughtPokemonList.First(p => p.PokedexId == EncounterId)
                        .Forms.Add(new PokemonVariety
                        {
                            VarietyId = pokemonFormToRemove.VarietyId,
                            VarietyName = pokemonFormToRemove.VarietyName,
                            VarietyImageUrl = pokemonFormToRemove.VarietyImageUrl,
                            VarietyCryUrl = pokemonFormToRemove.VarietyCryUrl,
                            VarietyType = pokemonFormToRemove.VarietyType,
                            VarietyHeight = pokemonFormToRemove.VarietyHeight,
                            VarietyWeight = pokemonFormToRemove.VarietyWeight
                        });
                }
                else
                {
                    CaughtPokemonList.Add(new Pokemon
                    {
                        PokedexId = pokemonToRemove.PokedexId,
                        SpeciesName = pokemonToRemove.SpeciesName,
                        Forms = new List<PokemonVariety> {
                            new PokemonVariety {
                                VarietyId = pokemonFormToRemove.VarietyId,
                                VarietyName = pokemonFormToRemove.VarietyName,
                                VarietyImageUrl = pokemonFormToRemove.VarietyImageUrl,
                                VarietyCryUrl = pokemonFormToRemove.VarietyCryUrl,
                                VarietyType = pokemonFormToRemove.VarietyType,
                                VarietyHeight = pokemonFormToRemove.VarietyHeight,
                                VarietyWeight = pokemonFormToRemove.VarietyWeight
                            }
                        }
                    });
                }

                if (pokemonToRemove.Forms.Count() == 1)
                {
                    WildPokemonList.Remove(pokemonToRemove);
                }
                else
                {
                    pokemonToRemove.Forms.Remove(pokemonFormToRemove);
                }
            }

            if (WildPokemonList.Count == 0)
            {
                MessageBox.Show("Holy fucknuggets you actually caught 'em all!");
                return;
            }

            NewEncounter();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            NewEncounter();
        }

        private void releaseButton_Click(object sender, EventArgs e)
        {
            if (releasePokemonDdl.SelectedItem != null)
            {
                var pokemonToRemove = CaughtPokemonList.Where(p => p.Forms.Any(f => f.VarietyId.ToString() == releasePokemonDdl.SelectedValue)).FirstOrDefault();
                var pokemonFormToRemove = pokemonToRemove.Forms.FirstOrDefault(f => f.VarietyId.ToString() == releasePokemonDdl.SelectedValue);

                //Add back to wild list
                if (WildPokemonList.Any(x => x.PokedexId == pokemonToRemove.PokedexId))
                {
                    WildPokemonList.Where(x => x.PokedexId == pokemonToRemove.PokedexId)
                        .FirstOrDefault()
                        .Forms
                        .Add(new PokemonVariety
                        {
                            VarietyId = pokemonFormToRemove.VarietyId,
                            VarietyName = pokemonFormToRemove.VarietyName,
                            VarietyImageUrl = pokemonFormToRemove.VarietyImageUrl,
                            VarietyCryUrl = pokemonFormToRemove.VarietyCryUrl,
                            VarietyType = pokemonFormToRemove.VarietyType,
                            VarietyHeight = pokemonFormToRemove.VarietyHeight,
                            VarietyWeight = pokemonFormToRemove.VarietyWeight
                    });
                }
                else
                {
                    WildPokemonList.Add(new Pokemon
                    {
                        PokedexId = pokemonToRemove.PokedexId,
                        SpeciesName = pokemonToRemove.SpeciesName,
                        Forms = new List<PokemonVariety> {
                            new PokemonVariety {
                                VarietyId = pokemonFormToRemove.VarietyId,
                                VarietyName = pokemonFormToRemove.VarietyName,
                                VarietyImageUrl = pokemonFormToRemove.VarietyImageUrl,
                                VarietyCryUrl = pokemonFormToRemove.VarietyCryUrl,
                                VarietyType = pokemonFormToRemove.VarietyType,
                                VarietyHeight = pokemonFormToRemove.VarietyHeight,
                                VarietyWeight = pokemonFormToRemove.VarietyWeight
                            }
                        }
                    });
                }

                if (pokemonToRemove.Forms.Count() == 1)
                {
                    CaughtPokemonList.Remove(pokemonToRemove);
                }
                else
                {
                    pokemonToRemove.Forms.Remove(pokemonFormToRemove);
                }

                releasePokemonDdl.DataSource = null;
            }
            else
            {
                MessageBox.Show("No Pokemon selected to release.");
            }
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

                    //Get Type(s)
                    string? primaryType = null;
                    string? secondaryType = null;
                    if (varietyRoot.TryGetProperty("types", out JsonElement types))
                    {
                        foreach (JsonElement typeEntry in types.EnumerateArray())
                        {
                            if (typeEntry.GetProperty("slot").GetInt32() == 1)
                            {
                                JsonElement typeObj = typeEntry.GetProperty("type");
                                primaryType = FirstCharToUpper(typeObj.GetProperty("name").GetString());
                            }
                            else if (typeEntry.GetProperty("slot").GetInt32() == 2)
                            {
                                JsonElement typeObj = typeEntry.GetProperty("type");
                                secondaryType = FirstCharToUpper(typeObj.GetProperty("name").GetString());
                            }
                        }
                    }

                    //Get height
                    double heightConversionValue = 0.3048;
                    double heightNumber = varietyRoot.GetProperty("height").GetDouble();
                    double heightFeetTotal = (heightNumber / 10) / heightConversionValue;
                    int feet = (int)heightFeetTotal;
                    double tempInches = (heightFeetTotal - Math.Truncate(heightFeetTotal)) / 0.08333;
                    int inches = (int)Math.Round(tempInches);

                    //Get weight
                    double weightConversionValue = 2.205;
                    double weightNumber = varietyRoot.GetProperty("weight").GetDouble() / 10;
                    double weightPounds = weightNumber * weightConversionValue;
                    weightPounds = Math.Round(weightPounds, 1);

                    varietiesList.Add(new PokemonVariety
                    {
                        VarietyId = varietyId,
                        VarietyName = varietyName,
                        VarietyImageUrl = artworkUrl,
                        VarietyCryUrl = cryUrl,
                        VarietyType = secondaryType != null ? $"{primaryType}/{secondaryType}" : primaryType,
                        VarietyHeight = $"{feet}'{inches}\"",
                        VarietyWeight = $"{weightPounds} lbs"
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

            //Store the encounter info
            EncounterId = pokemonSpecies.PokedexId;
            EncounterVarietyId = pokemonEncounter.VarietyId;

            // Update the UI with the pokemon data
            displayMessage.Text = $"A wild {pokemonEncounter.VarietyName} appeared!";
            pokedexNumber.Text = $"#{pokemonSpecies.PokedexId}";
            typeValue.Text = pokemonEncounter.VarietyType ?? "Unknown";
            heightValue.Text = pokemonEncounter.VarietyHeight ?? "Unknown";
            weightValue.Text = pokemonEncounter.VarietyWeight ?? "Unknown";

            pokemonImage.Load(pokemonEncounter.VarietyImageUrl);
            PlayOggFileFromUrl(pokemonEncounter.VarietyCryUrl);

            //Start the countdown timer
            CountdownValue = 60;
            Timer.Text = CountdownValue.ToString();
            Countdown.Start();
        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            if (CountdownValue == 0)
            {
                Countdown.Stop();
                return;
            }

            CountdownValue = CountdownValue - 1;
            Timer.Text = CountdownValue.ToString();
        }

        public string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input[0].ToString().ToUpper() + input.Substring(1);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string pokedexNum = searchPokemontxt.Text;
            var pokemon = CaughtPokemonList.FirstOrDefault(p => p.PokedexId.ToString() == pokedexNum);

            if (pokemon != null)
            {
                releasePokemonDdl.DataSource = pokemon.Forms;
                releasePokemonDdl.ValueMember = "VarietyId";
                releasePokemonDdl.DisplayMember = "VarietyName";
            }
            else
            { 
                MessageBox.Show("Pokemon not found in caught box.");
            }
        }
    }
}
