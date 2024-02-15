using System;
using PokemonReviewApi.Data;
using PokemonReviewApi.Interfaces;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
		{
            this._context = context;
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories
                .Where(c => c.CategoryId == categoryId)
                .Select(c => c.Pokemon)
                .ToList();
        }
    }
}

