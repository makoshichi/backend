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
    public class UsersController : Controller
    {
        private TestDbContext context;

        public UsersController(TestDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            //NO AUTH

            var response = JsonConvert.SerializeObject(ModelToDto.ConvertUserList(context.Users.ToList()));
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateDelete([FromBody] UserDto user)
        {
            //NO AUTH

            try
            {
                if (user.id == 0)
                    context.Users.Add((User)user);
                else
                {
                    var dbUser = context.Users.Single(x => x.Id == user.id);
                    context.Users.Remove(dbUser);
                }
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