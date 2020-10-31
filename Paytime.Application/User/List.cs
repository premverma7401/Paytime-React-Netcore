using MediatR;
using Microsoft.EntityFrameworkCore;
using Paytime.Domain;
using Paytime.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paytime.Application.User
{
    public class List
    {

        public class Query : IRequest<List<UserModel>>
        {
        }

        public class Handler : IRequestHandler<Query, List<UserModel>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<UserModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Users.Include(x=>x.Timesheets).ToListAsync();
            }

        }
    }

}


