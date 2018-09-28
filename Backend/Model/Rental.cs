using Backend.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Backend.Model
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        public List<Movie> MovieList { get; set; }
        public int RegistrationNumber { get; set; } // CPF
        public DateTime Date { get; set; }

        public static explicit operator Rental(RentalDto dto) => new Rental()
        {
            Date = DateTime.Now,
            MovieList = ConvertToMovies(dto.movieList).ToList(),
            Id = dto.id,
            RegistrationNumber = dto.nationalRegistrationNumber
        };

        public static implicit operator RentalDto(Rental rental)
        {
            return new RentalDto()
            {
                id = rental.Id,
                movieList = ConvertToMoviesDto(rental.MovieList).ToList(),
                nationalRegistrationNumber = rental.RegistrationNumber,
                token = string.Empty
            };
        }

        public static IEnumerable<Movie> ConvertToMovies(List<MovieDto> movieDtos)
        {
            foreach(var dto in movieDtos)
                yield return (Movie)dto;
        }

        public static IEnumerable<MovieDto> ConvertToMoviesDto(List<Movie> movies)
        {
            foreach (var movie in movies)
                yield return movie;
        }
    }
}
