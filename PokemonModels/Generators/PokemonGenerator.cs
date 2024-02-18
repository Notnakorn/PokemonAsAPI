using PokemonModels;

public static class PokemonGenerator
{
    private static Random random = new Random();
    private static List<string> usedNames = new List<string>();
    private static List<string> usedDescriptions = new List<string>();

    public static PokemonBaseModel GeneratePokemon()
    {
        var pokemon = new PokemonBaseModel
        {
            Name = GenerateUniqueName(),
            Description = GenerateUniqueDescription(),
            HitPoints = GenerateStat(Stat.HitPoint),
            Attack = GenerateStat(Stat.Attack),
            SpecialAttack = GenerateStat(Stat.SpecialAttack),
            Defense = GenerateStat(Stat.Defense),
            SpecialDefense = GenerateStat(Stat.SpecialDefense),
            Speed = GenerateStat(Stat.Speed)
        };

        return pokemon;
    }

    private static string GenerateUniqueName()
    {
        string name;
        do
        {
            name = "Poke" + random.Next(1000, 9999) + "mon";
        } while (usedNames.Contains(name));
        usedNames.Add(name);
        return name;
    }

    private static string GenerateUniqueDescription()
    {
        string description;
        do
        {
            description = "Description number: " + random.Next(1000, 9999);
        } while (usedDescriptions.Contains(description));
        usedDescriptions.Add(description);
        return description;
    }

    private static PokemonStat GenerateStat(Stat statType)
    {
        return new PokemonStat
        {
            StatType = statType,
            Value = random.Next(1, 256)
        };
    }
}