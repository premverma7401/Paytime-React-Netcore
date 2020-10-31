using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paytime.Application.Interfaces;
using Paytime.Domain;
using Paytime.Persistence;

namespace Paytime.Application.User
{
    public class Register
    {
        public class Command : IRequest<User>
        {
            public string DisplayName { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext _context;
            private readonly UserManager<UserModel> _userManager;
            private readonly IJwtGenerator _jwt;

            public Handler(DataContext context, UserManager<UserModel> userManager, IJwtGenerator jwt)
            {
                _jwt = jwt;
                _userManager = userManager;
                _context = context;

            }
            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Users.AnyAsync(x => x.Email == request.Email))
                {
                    throw new Exception("Email already exist");
                }
                if (await _context.Users.AnyAsync(x => x.UserName == request.Username))
                {
                    throw new Exception("Username already exist");
                }
                var user = new UserModel
                {
                    DisplayName = request.DisplayName,
                    Email = request.Email,
                    UserName = request.Username
                };
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return new User
                    {
                        DisplayName = user.DisplayName,
                        Token = _jwt.CreateToken(user),
                        Username = user.UserName,
                        Image = null
                    };
                }
                throw new Exception("Error Creating user");


            }
        }
    }
}