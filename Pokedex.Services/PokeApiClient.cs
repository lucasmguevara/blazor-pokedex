﻿using Newtonsoft.Json;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient;

        public PokeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            var pokemonList = JsonConvert.DeserializeObject<ResultObject>(await _httpClient.GetStringAsync($"pokemon?limit=24&offset=24"));

            var resultList = new List<Pokemon>();

            foreach (var item in pokemonList.Pokemons)
            {
                resultList.Add(await GetPokemonByName(item.Name));
            }

            return resultList;
        }

        public async Task<Pokemon> GetPokemonByName(string name)
        {
            return JsonConvert.DeserializeObject<Pokemon>(await _httpClient.GetStringAsync($"pokemon/{name}"));
        }
    }
}
