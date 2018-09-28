using System.Collections.Generic;

namespace Backend.DTO
{
    public class RentalDto
    {
        public int id { get; set; }
        public List<MovieDto> movieList { get; set; } // uma locação pode ter vários filmes
        public int nationalRegistrationNumber { get; set; }
        public string token { get; set; }
    }
}
