using System;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class PokemonController : Controller
	{
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
		{
            this._pokemonRepository = pokemonRepository;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]

		public async Task<IActionResult> GetPokemons()
		{
			var pokemons = await _pokemonRepository.GetPokemonsAsync();
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemons);
		}
	}
}

