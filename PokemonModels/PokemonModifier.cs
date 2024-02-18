using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonModels
{
    public class PokemonModifier
    {
        public bool TargetingEnemy { get; set; } = true;
        public int Value { get; set; }

        public Stat StatToModify { get; set; } = Stat.NA;
    }
}
