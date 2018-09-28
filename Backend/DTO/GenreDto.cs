using Backend.Model;
using System;

namespace Backend.DTO
{
    public class GenreDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public string token { get; set; }

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
