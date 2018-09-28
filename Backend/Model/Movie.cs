using Backend.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }
        public Genre Genre { get; set; }

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
                genreId= movie.Genre.Id,
                active = movie.Active,
                token = string.Empty
            };
        }
    }
}
