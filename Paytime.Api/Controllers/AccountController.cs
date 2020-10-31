using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paytime.Application.User;
using Paytime.Domain;

namespace Paytime.Api.Controllers
{

    [AllowAnonymous]
    public class AccountController : BaseController
    {

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("currentUser")]

        public async Task<ActionResult<User>> GetCurrentUser()
        {
            return await Mediator.Send(new CurrentUser.Query());
        }

        [HttpGet("list")]

        public async Task<ActionResult<List<UserModel>>> GetList()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}
