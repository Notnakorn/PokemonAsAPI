using PokemonModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

var pokemonList = new List<PokemonBaseModel>
{
    new PokemonBaseModel{ Name="Bulbasaur", Attack={StatType = Stat.Attack, Value=5}, Defense={StatType = Stat.Defense, Value=5}, HitPoints={StatType = Stat.HitPoint, Value=14}, Speed={StatType = Stat.Speed, Value=3}, SpecialAttack={StatType = Stat.SpecialAttack, Value=6}, SpecialDefense={StatType = Stat.SpecialDefense, Value=8}, Description="The grass starter pokemon" },
    new PokemonBaseModel{ Name="Squirtle", Attack={StatType = Stat.Attack, Value=6}, Defense={StatType = Stat.Defense, Value=7}, HitPoints={StatType = Stat.HitPoint, Value=15}, Speed={StatType = Stat.Speed, Value=4}, SpecialAttack={StatType = Stat.SpecialAttack, Value=7}, SpecialDefense={StatType = Stat.SpecialDefense, Value=9}, Description="The water starter pokemon" },
    new PokemonBaseModel{ Name="Charmander", Attack={StatType = Stat.Attack, Value=7}, Defense={StatType = Stat.Defense, Value=3}, HitPoints={StatType = Stat.HitPoint, Value=13}, Speed={StatType = Stat.Speed, Value=6}, SpecialAttack={StatType = Stat.SpecialAttack, Value=8}, SpecialDefense={StatType = Stat.SpecialDefense, Value=6}, Description="The fire starter pokemon" },
    new PokemonBaseModel{ Name="Rattata", Attack={StatType = Stat.Attack, Value=4}, Defense={StatType = Stat.Defense, Value=3}, HitPoints={StatType = Stat.HitPoint, Value=12}, Speed={StatType = Stat.Speed, Value=7}, SpecialAttack={StatType = Stat.SpecialAttack, Value=4}, SpecialDefense={StatType = Stat.SpecialDefense, Value=4}, Description="A normal type rat pokemon usually found in the beginning of the game" },
    new PokemonBaseModel{ Name="Pidgey", Attack={StatType = Stat.Attack, Value=5}, Defense={StatType = Stat.Defense, Value=4}, HitPoints={StatType = Stat.HitPoint, Value=13}, Speed={StatType = Stat.Speed, Value=8}, SpecialAttack={StatType = Stat.SpecialAttack, Value=5}, SpecialDefense={StatType = Stat.SpecialDefense, Value=5}, Description="A flying type bird pokemon usually found in the beginning of the game" },
    new PokemonBaseModel{ Name="Oddish", Attack={StatType = Stat.Attack, Value=5}, Defense={StatType = Stat.Defense, Value=3}, HitPoints={StatType = Stat.HitPoint, Value=12}, Speed={StatType = Stat.Speed, Value=4}, SpecialAttack={StatType = Stat.SpecialAttack, Value=8}, SpecialDefense={StatType = Stat.SpecialDefense, Value=6}, Description="A grass type plant pokemon usually found in the beginning of the game" },
    new PokemonBaseModel{ Name="Pikachu", Attack={StatType = Stat.Attack, Value=6}, Defense={StatType = Stat.Defense, Value=4}, HitPoints={StatType = Stat.HitPoint, Value=15}, Speed={StatType = Stat.Speed, Value=9}, SpecialAttack={StatType = Stat.SpecialAttack, Value=9}, SpecialDefense={StatType = Stat.SpecialDefense, Value=4}, Description="The most iconic pokemon of them all. The lightning starter" },
};

app.MapGet("/allPokemons", () =>
{
    return pokemonList;
})
.WithName("GetAllPokemons");

app.MapPost("/addPokemonToList", (PokemonBaseModel pokemonToAdd) =>
{
    pokemonList.Add(pokemonToAdd);
    return Results.Ok(pokemonToAdd);
}).WithName("AddPokemonToList");

app.MapPost("/addManyPokemonToList", (List<PokemonBaseModel> pokemonsToAdd) =>
{
    foreach (var pokemon in pokemonsToAdd)
    {
        pokemonList.Add(pokemon);
    }
    return Results.Ok(pokemonsToAdd);
}).WithName("addManyPokemonToList");

app.Run();

