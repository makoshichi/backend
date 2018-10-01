using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.DTO
{
    public class RentalDto
    {
        public int id { get; set; }
        public List<MovieDto> movieList { get; set; } // uma locação pode ter vários filmes
        public int nationalRegistrationNumber { get; set; }

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
                nationalRegistrationNumber = rental.RegistrationNumber
            };
        }

        public static IEnumerable<Movie> ConvertToMovies(List<MovieDto> movieDtos)
        {
            foreach (var dto in movieDtos)
                yield return (Movie)dto;
        }

        public static IEnumerable<MovieDto> ConvertToMoviesDto(List<Movie> movies)
        {
            foreach (var movie in movies)
                yield return movie;
        }
    }
}
