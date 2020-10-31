using System.Net.Mime;

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
    public class UpdateUserProfile
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string DisplayName { get; set; }
            public string Image { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public ContractType Contract { get; set; }
            public string COA { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _user;

            public Handler(DataContext context, IUserAccessor user)
            {
                _user = user;
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(x => x.UserName == _user.GetCurrentUser()).FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("No User to update");
                }
                user.DisplayName = request.DisplayName;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Image = request.Image;
                user.Contract = request.Contract;
                user.COA = request.COA;

                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                throw new Exception("can not edit");

            }
        }
    }
}