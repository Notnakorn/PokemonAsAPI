using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PokemonModels
{
    public class PokemonStat
    {
        public Stat StatType { get; set; }
        public int Value { get; set; }
    }
}