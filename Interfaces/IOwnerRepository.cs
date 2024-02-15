using System;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
	public interface IOwnerRepository
	{
		ICollection<Owner> GetOwners();

		Owner GetOwner(int id);

		bool OwnerExists(int ownerId);
	}
}

