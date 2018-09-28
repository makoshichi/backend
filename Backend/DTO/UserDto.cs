using Backend.Model;

namespace Backend.DTO
{
    public class UserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string token { get; set; }

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
