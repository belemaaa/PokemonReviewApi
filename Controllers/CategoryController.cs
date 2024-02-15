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

    public class CategoryController : Controller
	{
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
		{
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        //get all categories
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);
        }

        //get category by id
        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCategory(int categoryId)
        {
            bool categoryExists = _categoryRepository.CategoryExists(categoryId);
            if (!categoryExists)
            {
                return NotFound("Object not found");
            }

            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(category);
        }

        //get pokemon by category
        [HttpGet("{categoryId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        public IActionResult GetPokemonByCategory(int categoryId)
        {
            bool categoryExists = _categoryRepository.CategoryExists(categoryId);
            if (!categoryExists)
            {
                return NotFound("Object not found");
            }

            var pokemon = _categoryRepository.GetPokemonByCategory(categoryId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }
    }
}

