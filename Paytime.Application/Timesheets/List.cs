
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paytime.Application.Interfaces;
using Paytime.Domain;
using Paytime.Persistence;

namespace Paytime.Application.Timesheets
{
    public class List
    {
        public class Query : IRequest<List<WeeklyDataModel>>
        {
        }

        public class Handler : IRequestHandler<Query, List<WeeklyDataModel>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _user;

            public Handler(DataContext context, IUserAccessor user)
            {
                _context = context;
                _user = user;
            }

            public async Task<List<WeeklyDataModel>> Handle(Query request, CancellationToken cancellationToken)
            {

                var timesheets = await _context.Timesheets.Include(x => x.DailyData)
                                                .ThenInclude(x => x.ShiftData)
                                                // .Where(x=>x.CreatedBy == _user.GetCurrentUser())
                                                .ToListAsync();
                foreach (var sheets in timesheets)
                {
                    sheets.DailyData = sheets.DailyData.OrderBy(x => x.Day).ToList();
                }
                return timesheets;
            }

        }
    }

}


