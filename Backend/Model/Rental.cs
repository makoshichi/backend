using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        public List<Movie> MovieList { get; set; }
        public int RegistrationNumber { get; set; } // CPF
        public DateTime Date { get; set; }
    }
}
