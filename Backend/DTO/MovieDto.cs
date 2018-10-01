using Backend.Model;
using System;

namespace Backend.DTO
{
    public class MovieDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int genreId { get; set; }
        public bool active { get; set; }

        public static explicit operator Movie(MovieDto dto)
        {
            return new Movie()
            {
                DateTime = DateTime.Now,
                Genre = new Genre() { Id = dto.genreId },
                Name = dto.name,
                Active = dto.active
            };
        }

        public static implicit operator MovieDto(Movie movie)
        {
            return new MovieDto()
            {
                id = movie.Id,
                name = movie.Name,
                genreId = movie.Genre.Id,
                active = movie.Active
            };
        }
    }
}
