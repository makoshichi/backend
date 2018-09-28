using Backend.Auth;
using Backend.Context;
using Backend.DTO;
using Backend.Misc;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private TestDbContext context;

        public MoviesController(TestDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("[action")]
        public IActionResult Get(Token token)
        {
            //NO AUTH

            var response = JsonConvert.SerializeObject(ModelToDto.ConvertMovieList(context.Movies.ToList()));
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateUpdate([FromBody] MovieDto movie)
        {
            //NO AUTH
            try
            {
                if (movie.id == 0)
                {
                    context.Movies.Add((Movie)movie);
                    context.SaveChanges();
                }
                else
                {
                    var existing = context.Movies.First(x => x.Id == movie.id);
                    existing.Name = movie.name;
                    existing.Genre = new Genre() { Id = movie.genreId };
                    context.Update(existing);
                }

                return Ok(200);
            }
            catch (Exception) // Find what is Error 403 in exception form
            {
                return StatusCode(403);
            }
            //catch (Exception)
            //{
            //    return StatusCode(401);
            //}
            //catch (Exception)
            //{
            //    return StatusCode(404);
            //}
            //catch (Exception)
            //{
            //    return StatusCode(406);
            //}
        }

        [HttpPost]
        [Route("[action")]
        public IActionResult Delete([FromBody] MovieDto dto)
        {
            //NO AUTH

            try
            {
                var movie = context.Movies.SingleOrDefault(x => x.Id == dto.id);
                movie.Active = false;
                context.Movies.Update(movie);
                context.SaveChanges();
                return Ok(200);
            }
            catch (Exception)
            {
                return StatusCode(401); // Bad request exception
            }
        }
    }
}
