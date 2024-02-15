using System;
using PokemonReviewApi.Data;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Repositories
{
	public class OwnerRepository : IOwnerRepository
	{
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
		{
            this._context = context;
        }

        public Owner GetOwner(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Owner> GetOwners()
        {
            throw new NotImplementedException();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }
    }
}

