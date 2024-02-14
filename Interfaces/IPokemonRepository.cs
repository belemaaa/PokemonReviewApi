using System;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
	public interface IPokemonRepository
	{
		Task<ICollection<Pokemon>> GetPokemonsAsync();

		bool Add(Pokemon Pokemon);

		bool Update(Pokemon Pokemon);

		bool Delete(Pokemon Pokemon);

		bool Save();
	}
}

