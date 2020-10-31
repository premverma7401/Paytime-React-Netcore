using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paytime.Domain.models.viewModels;
using Paytime.Persistence;

namespace Paytime.Application.Timesheets
{
    public class TimesheetDetail
    {
        public class Query : IRequest<List<DetailCardViewModel>> { public Guid Id { get; set; } }
        public class Handler : IRequestHandler<Query, List<DetailCardViewModel>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<DetailCardViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var detailCardData = await _context.DailyData.Where(x => x.TsheetId == request.Id).Select(x => new DetailCardViewModel
                {
                    Day = x.Day,
                    ShiftData = x.ShiftData.Select(x => new DetailCardViewModelShift
                    {
                        SiteName = x.SiteName,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        ShiftHourTotal = x.ShiftHourTotal,
                        ShiftNotes = x.ShiftNotes,
                    }).ToList()
                }).ToListAsync();

                return detailCardData;
            }
        }
    }
}