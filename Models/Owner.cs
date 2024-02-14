using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonReviewApi.Models
{
	public class Owner
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Gym { get; set; }

		public Country Country { get; set; }
	}
}

