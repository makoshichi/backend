using Backend.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }

        public static explicit operator Genre(GenreDto dto)
        {
            return new Genre()
            {
                Id = dto.id,
                Name = dto.name,
                DateTime = DateTime.Now,
                Active = dto.active
            };
        }

        public static implicit operator GenreDto(Genre genre)
        {
            return new GenreDto()
            {
                id = genre.Id,
                active = genre.Active,
                name = genre.Name,
                token = string.Empty
            };
        }
    }
}
