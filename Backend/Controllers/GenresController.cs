using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Auth;
using Backend.Context;
using Backend.DTO;
using Backend.Misc;
using Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {
        private TestDbContext context;

        public GenresController(TestDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("[action")]
        public IActionResult Get(Token token)
        {
            var response = JsonConvert.SerializeObject(ModelToDto.ConvertGenreList(context.Genres.ToList()));
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateUpdate([FromBody] GenreDto genre)
        {
            context.Genres.Add((Genre)genre);
            try
            {
                context.SaveChanges();
                return Ok(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
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

        [HttpDelete]
        [Route("[action")]
        public IActionResult DeleteGenre([FromBody] GenreDto dto)
        {
            try
            {
                var genre = context.Genres.SingleOrDefault(x => x.Id == dto.id);
                genre.Active = false;
                context.Genres.Update(genre);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
