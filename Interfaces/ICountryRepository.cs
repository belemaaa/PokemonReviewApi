using System;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Interfaces
{
	public interface ICountryRepository
	{
		ICollection<Country> GetCountries();

		Country GetCountry(int id);

		Country GetCountryByOwners(int ownerId);

		ICollection<Owner> GetOwnersFromACountry(int countryId);

		bool CountryExists(int id);
	}
}

