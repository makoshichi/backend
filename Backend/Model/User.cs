using Backend.DTO;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public static explicit operator User(UserDto dto)
        {
            return new User()
            {
                Id = dto.id,
                Name = dto.name,
                Password = dto.password // Password encryption here
            };
        }

        public static implicit operator UserDto(User user)
        {
            return new UserDto()
            {
                id = user.Id,
                name = user.Name,
                password = user.Password, // Yeah...
                token = string.Empty
            };
        }
    }
}
