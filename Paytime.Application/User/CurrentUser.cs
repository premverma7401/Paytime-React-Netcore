using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Paytime.Application.Interfaces;
using Paytime.Domain;

namespace Paytime.Application.User
{
    public class CurrentUser
    {
        public class Query : IRequest<User>
        {

        }
        public class Handler : IRequestHandler<Query, User>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IJwtGenerator _jwt;
            private readonly UserManager<UserModel> _userManager;
            public Handler(UserManager<UserModel> userManager, IJwtGenerator jwt, IUserAccessor userAccessor)
            {
                _userManager = userManager;
                _jwt = jwt;
                _userAccessor = userAccessor;

            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUser());
                return new User
                {
                    DisplayName = user.DisplayName,
                    Username = user.UserName,
                    Image = null,
                    Token = _jwt.CreateToken(user)
                };
            }
        }
    }
}