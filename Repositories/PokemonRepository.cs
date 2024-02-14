using System;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApi.Data;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationDbContext _context;

        public PokemonRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public bool Add(Pokemon Pokemon)
        {
            this._context.Add(Pokemon);
            return Save();
        }

        public bool Delete(Pokemon Pokemon)
        {
            this._context.Remove(Pokemon);
            return Save();
        }

        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Pokemon Pokemon)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Pokemon>> GetPokemonsAsync()
        {
            return await _context.Pokemon.OrderBy(p => p.Id).ToListAsync();
        }
    }
}

