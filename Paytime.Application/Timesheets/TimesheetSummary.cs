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
    public class TimesheetSummary
    {
        public class Query : IRequest<List<SummaryCardViewModel>> { }
        public class Handler : IRequestHandler<Query, List<SummaryCardViewModel>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<List<SummaryCardViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var summary = await _context.Timesheets.Select(x => new SummaryCardViewModel
                {
                    TsheetId = x.TsheetId,
                    MainSite = x.MainSite,
                    DaysOff = x.DaysOff,
                    DaysWorked = x.DaysWorked,
                    WeekHoursTotal = x.WeekHoursTotal,
                    WeekRange = x.WeekRange,
                    Created = x.Created,
                    CreatedBy = x.CreatedBy,
                    LastModified = x.LastModified,
                    LastModifiedBy = x.LastModifiedBy
                }).ToListAsync();
                return summary;
            }
        }
    }
}