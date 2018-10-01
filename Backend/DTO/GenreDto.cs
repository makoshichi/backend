using Backend.Model;
using System;

namespace Backend.DTO
{
    public class GenreDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }

        // GenreDto to Genre cast (explicit, has data loss)
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

        // Genre to GenreDto cast (implicit, no data loss)
        public static implicit operator GenreDto(Genre genre)
        {
            return new GenreDto()
            {
                id = genre.Id,
                active = genre.Active,
                name = genre.Name
            };
        }
    }
}
