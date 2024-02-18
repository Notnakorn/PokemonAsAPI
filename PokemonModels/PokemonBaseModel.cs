namespace PokemonModels
{
    public class PokemonBaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }

        public PokemonStat HitPoints { get; set; } = new PokemonStat { StatType = Stat.HitPoint, Value = 0 };

        public PokemonStat Attack { get; set; } = new PokemonStat { StatType = Stat.Attack, Value = 0 };
        public PokemonStat SpecialAttack { get; set; } = new PokemonStat { StatType = Stat.SpecialAttack, Value = 0 };

        public PokemonStat Defense { get; set; } = new PokemonStat { StatType = Stat.Defense, Value = 0 };

        public PokemonStat SpecialDefense { get; set; } = new PokemonStat { StatType = Stat.SpecialDefense, Value = 0 };

        public PokemonStat Speed { get; set; } = new PokemonStat { StatType = Stat.Speed, Value = 0 };
    }
}
