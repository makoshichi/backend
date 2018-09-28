using Backend.DTO;
using Backend.Model;
using System.Collections;
using System.Collections.Generic;

namespace Backend.Misc
{
    public class ModelToDto
    {
        public static IEnumerable<GenreDto> ConvertGenreList(List<Genre> genres)
        {
            foreach (var genre in genres)
                yield return genre;
        }

        public static IEnumerable<MovieDto> ConvertMovieList(List<Movie> movies)
        {
            foreach (var movie in movies)
                yield return movie;
        }

        public static IEnumerable<UserDto> ConvertUserList(List<User> users)
        {
            foreach (var user in users)
                yield return user;
        }

        public static IEnumerable<RentalDto> ConvertRentalList(List<Rental> rentals)
        {
            foreach (var rental in rentals)
                yield return rental;
        }
    }
}
