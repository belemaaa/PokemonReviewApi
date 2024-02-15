using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApi.Dto;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class PokemonController : Controller
	{
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
		{
            this._pokemonRepository = pokemonRepository;
            this._mapper = mapper;
        }


		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]

		public IActionResult GetPokemons()
		{
			var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(pokemons);
		}


		[HttpGet("{pokemonId}")]
		[ProducesResponseType(200, Type = typeof(Pokemon))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]

		public IActionResult GetPokemonById(int pokemonId)
		{
            bool pokemonExists = _pokemonRepository.PokemonExists(pokemonId);
			if (!pokemonExists)
			{
				return NotFound("Pokemon object not found");
			}

			var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokemonId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
		}


		[HttpGet("{pokemonId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

		public IActionResult GetPokemonRating(int pokemonId)
		{
			bool pokemonExists = _pokemonRepository.PokemonExists(pokemonId);
			if (!pokemonExists)
			{
				return NotFound("Pokemon object not found");
			}

			var pokemonRating = _pokemonRepository.GetPokemonRating(pokemonId);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(pokemonRating);
		}

    }
}

