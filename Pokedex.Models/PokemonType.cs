using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PokemonType
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
