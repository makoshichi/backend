using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
