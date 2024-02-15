using System;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApi.Data;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationDbContext _context;

        public PokemonRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            var reviews = _context.Reviews.Where(p => p.Pokemon.Id == pokemonId);
            if (!reviews.Any())
                return 0;

            return Math.Round(((decimal)reviews.Sum(r => r.Rating) / reviews.Count()), 2);
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokemonId)
        {
            return _context.Pokemon.Any(p => p.Id == pokemonId);
        }
    }
}

