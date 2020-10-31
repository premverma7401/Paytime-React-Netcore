using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paytime.Application.User;

namespace Paytime.Api.Controllers
{

    public class UserController : BaseController
    {
        [AllowAnonymous]

        [HttpGet("{usernameprofile}")]
        public async Task<ActionResult<UserInfo>> UserProfile(string username)
        {
            return await Mediator.Send(new ViewUserProfile.Query { Username = username });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, UpdateUserProfile.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

    }
}