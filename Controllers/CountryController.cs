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

    public class CountryController : Controller
	{
        private readonly ICountryRepository _countryRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IOwnerRepository ownerRepository, IMapper mapper)
		{
            this._countryRepository = countryRepository;
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
        }

        //get all countries
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        //get country by id
        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCountry(int countryId)
        {
            bool countryExists = _countryRepository.CountryExists(countryId);
            if (!countryExists)
            {
                return NotFound("Object not found");
            }

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(country);
        }

        //get country by owners
        [HttpGet("{ownerId}/country")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCountryByOwners(int ownerId)
        {
            bool ownerExists = _ownerRepository.OwnerExists(ownerId);
            if (!ownerExists)
            {
                return NotFound("Object not found");
            }

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwners(ownerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(country);
        }

        //get owners from a country
        [HttpGet("{countryId}/owners")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetOwnersFromACountry(int countryId)
        {
            var countryExists = _countryRepository.CountryExists(countryId);
            if (!countryExists)
            {
                return NotFound("Object not found");
            }

            var countryOwners = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersFromACountry(countryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(countryOwners);
           
        }
    }
}

