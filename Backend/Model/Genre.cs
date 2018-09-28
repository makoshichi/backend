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
    }
}
