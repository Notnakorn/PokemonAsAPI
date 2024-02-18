using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonModels
{
    internal class PokemonMoveModel
    {
        public int Power { get; set; }

        public Type MoveType { get; set; }

        public string? Name { get; set; }

        public List<PokemonModifier>? MoveEffects { get; set; }

    }
}
