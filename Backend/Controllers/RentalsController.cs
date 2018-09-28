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
    public class RentalsController : ControllerBase
    {
        private TestDbContext context;

        public RentalsController(TestDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("[action")]
        public IActionResult Get(Token token)
        {
            //NO AUTH

            var response = JsonConvert.SerializeObject(ModelToDto.ConvertRentalList(context.Rentals.ToList()));
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] RentalDto rental)
        {
            //NO AUTH

            try
            {

                context.Rentals.Add((Rental)rental);
                context.SaveChanges();
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
    }
}


