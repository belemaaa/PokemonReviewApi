﻿using System;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
	public interface IPokemonRepository
	{
		ICollection<Pokemon> GetPokemons();

		Pokemon GetPokemon(int id);

		Pokemon GetPokemon(string name);

		decimal GetPokemonRating(int pokemonId);

		bool PokemonExists(int pokemonId);
	}
}

