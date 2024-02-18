using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonModels;

namespace PokemonConsumer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IList<PokemonBaseModel> PokemonsFromAPI { get; set; }

        [BindProperty]
        public PokemonBaseModel PokemonToAdd { get; set; } = new PokemonBaseModel
        {
            Attack = {StatType = Stat.Attack, Value = 0},
            Defense = { StatType = Stat.Defense, Value = 0 },
            SpecialAttack = { StatType = Stat.SpecialAttack, Value = 0 },
            SpecialDefense = { StatType = Stat.SpecialDefense, Value = 0 },
            HitPoints = { StatType = Stat.HitPoint, Value = 0 },
            Speed = { StatType = Stat.Speed, Value = 0 },
        };

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnPostLoadPokemonsAsync()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7065/allPokemons");
            var pokemonsRawJson = await response.Content.ReadFromJsonAsync<IEnumerable<PokemonBaseModel>>();
            
            if(pokemonsRawJson != null)
            {
                PokemonsFromAPI = pokemonsRawJson.ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddPokemonAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (PokemonToAdd != null && !string.IsNullOrWhiteSpace(PokemonToAdd.Name))
            {
                using var httpClient = new HttpClient();
                var result = await httpClient.PostAsJsonAsync("https://localhost:7065/addPokemonToList", PokemonToAdd);
                if(!result.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Error");
                }
            }
            else
            {
                return RedirectToPage("./Error");
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostAdd100RandomPokemonAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var listOfPokemonsToAdd = new List<PokemonBaseModel>();

            for (int i = 0; i < 100; i++)
            {
                listOfPokemonsToAdd.Add(PokemonGenerator.GeneratePokemon());
            }

            if (listOfPokemonsToAdd != null && listOfPokemonsToAdd.Count > 0)
            {
                using var httpClient = new HttpClient();
                var httpResponseMessage = await httpClient.PostAsJsonAsync("https://localhost:7065/addManyPokemonToList", listOfPokemonsToAdd);
                
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Error");
                }
            }
            else
            {
                return RedirectToPage("./Error");
            }

            return RedirectToPage("./Index");
        }
    }
}
