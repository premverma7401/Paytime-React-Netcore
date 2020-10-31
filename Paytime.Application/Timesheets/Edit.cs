using System.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paytime.Application.Errors;
using Paytime.Application.Interfaces;
using Paytime.Domain;
using Paytime.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Paytime.Application.Timesheets
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string MainSite { get; set; }
            public string WeekRange { get; set; }
            public decimal WeekHoursTotal { get; set; }
            public int DaysWorked { get; set; }
            public int DaysOff { get; set; }
            public List<DailyDataModel> DailyData { get; set; }
            public List<ShiftDataModel> ShiftData { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _user;

            public Handler(DataContext context, IUserAccessor user)
            {
                _context = context;
                _user = user;
            }
            /// <summary>
            /// Add  Last Modified property by logged in user.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var timesheet = await _context.Timesheets.Include(x => x.DailyData)
                    .ThenInclude(x => x.ShiftData)
                    .Where(x => x.TsheetId == request.Id).Where(x => x.CreatedBy == _user.GetCurrentUser())
                    .FirstOrDefaultAsync();

                if (timesheet == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { timesheet = "No ts found" });
                }

                timesheet.MainSite = request.MainSite;
                //timesheet.DailyData = request.DailyData.Select(x => new DailyDataModel
                //{
                //    Day = x.Day,
                //    ShiftData = request.ShiftData.Select(x => new ShiftDataModel
                //    {
                //        SiteName = x.SiteName,
                //        StartTime = x.StartTime,
                //        EndTime = x.EndTime,
                //        ShiftHourTotal = x.ShiftHourTotal,
                //        ShiftNotes = x.ShiftNotes
                //    }).ToList()

                //}).ToList();


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
