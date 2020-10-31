using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paytime.Application.Interfaces;
using Paytime.Persistence;

namespace Paytime.Application.User
{
    public class ViewUserProfile
    {
        public class Query : IRequest<UserInfo>
        {
            public string Username { get; set; }
        }
        public class Handler : IRequestHandler<Query, UserInfo>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _user;
            public Handler(DataContext context, IUserAccessor user)
            {
                _user = user;
                _context = context;

            }

            public async Task<UserInfo> Handle(Query request, CancellationToken cancellationToken)
            {

                // if (request.Username != _user.GetCurrentUser())
                // {
                //     throw new Exception("Not Allowed");
                // }
                var userInfo = await _context.Users.Where(x => x.UserName == request.Username).FirstOrDefaultAsync();
                return new UserInfo
                {
                    DisplayName = userInfo.DisplayName,
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    COA = userInfo.COA,
                    Contract = userInfo.Contract,
                    Image = userInfo.Image
                };
            }
        }
    }
}
