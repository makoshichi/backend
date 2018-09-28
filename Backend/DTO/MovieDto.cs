namespace Backend.DTO
{
    public class MovieDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int genreId { get; set; }
        public bool active { get; set; }
        public string token { get; set; }
    }
}
