using MediatR;
using Microsoft.AspNetCore.Identity;
using Paytime.Application.Interfaces;
using Paytime.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Paytime.Application.User
{
    public class Login
    {
        public class Query : IRequest<User>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<UserModel> _userManager;
            private readonly SignInManager<UserModel> _signInManager;
            private readonly IJwtGenerator _generator;

            public Handler(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IJwtGenerator generator)
            {
                _generator = generator;
                _userManager = userManager;
                _signInManager = signInManager;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    throw new Exception();
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded)
                {
                    return new User
                    {
                        DisplayName = user.DisplayName,
                        Token = _generator.CreateToken(user),
                        Username = user.UserName,
                        Image = null
                    };
                }
                throw new Exception();

            }
        }
    }
}
