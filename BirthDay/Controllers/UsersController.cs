using BirthDay.Model;
using BirthDay.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BirthDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IuserRepository iuser;
        public UsersController(IuserRepository user)
        {
            iuser = user ?? throw new ArgumentNullException(nameof(user));
        }
        [HttpGet]
        [Route("UserSelect")]
        public async Task<IActionResult> Get()
        {
            return Ok(await iuser.GetUser());
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Put(User user)
        {
            await iuser.UpdateUser(user);
            return Ok("ugurla deyisdirildi");
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> Post(User user)
        {
            var result = await iuser.insertUser(user);
            if (result.id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ugursuz");
            }
            return Ok("Ugurlu");
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public JsonResult Delete(int id)
        {
            iuser.DeleteUser(id);
            return new JsonResult("Ugurla Silini!");
        }
        [HttpGet]
        [Route("selectById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await iuser.GetUserByid(id));
        }
    }
}
