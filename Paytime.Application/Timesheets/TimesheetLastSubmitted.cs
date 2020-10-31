using MediatR;
using Microsoft.EntityFrameworkCore;
using Paytime.Application.Errors;
using Paytime.Application.Interfaces;
using Paytime.Domain.models.viewModels;
using Paytime.Persistence;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Paytime.Application.Timesheets
{
    public class TimesheetLastSubmitted
    {
        public class Query : IRequest<DetailLastTsSubmitted>
        {
            public string Username { get; set; }

        }
        public class Handler : IRequestHandler<Query, DetailLastTsSubmitted>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _user;

            public Handler(DataContext context, IUserAccessor user)
            {
                _context = context;
                _user = user;
            }

            public async Task<DetailLastTsSubmitted> Handle(Query request, CancellationToken cancellationToken)
            {
                var lastTsSubmitted = await _context.Timesheets.Where(x => x.CreatedBy == _user.GetCurrentUser())
                                                    .OrderByDescending(x => x.Created)
                                                    .Select(x => new DetailLastTsSubmitted
                                                    {
                                                        MainSite = x.MainSite,
                                                        DaysOff = x.DaysOff,
                                                        DaysWorked = x.DaysWorked,
                                                        WeekHoursTotal = x.WeekHoursTotal,
                                                        WeekRange = x.WeekRange,
                                                        Created = x.Created,
                                                        CreatedBy = x.CreatedBy,
                                                        DailyData = x.DailyData.Select(x => new DetailCardViewModel
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
                                                        }).ToList()
                                                    }).FirstAsync();

                if (lastTsSubmitted == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "No Last Timesheet Submitted");
                }
                return lastTsSubmitted;
            }
        }
    }
}
