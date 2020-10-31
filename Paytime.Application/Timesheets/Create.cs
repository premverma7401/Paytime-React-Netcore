using System.Net;
using FluentValidation;
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
    public class Create
    {
        public class Command : IRequest
        {
            public string MainSite { get; set; }
            public string WeekRange { get; set; }
            public decimal WeekHoursTotal { get; set; }
            public int DaysWorked { get; set; }
            public int DaysOff { get; set; }
            public DateTime Created { get; set; }
            public DateTime LastModified { get; set; }
            public List<DailyDataModel> DailyData { get; set; }
            public List<ShiftDataModel> ShiftData { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.WeekHoursTotal).NotEmpty();

            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUser());
                // if (user.UserName != _userAccessor.GetCurrentUser())
                // {
                //     throw new RestException(HttpStatusCode.Unauthorized, "User Unauthorized");
                // }
                var timesheet = new WeeklyDataModel
                {
                    LastModifiedBy = _userAccessor.GetCurrentUser(),
                    CreatedBy = _userAccessor.GetCurrentUser(),
                    MainSite = request.MainSite,
                    WeekRange = request.WeekRange,
                    WeekHoursTotal = request.WeekHoursTotal,
                    DaysWorked = request.DaysWorked,
                    LastModified = DateTime.Now,
                    Created = DateTime.Now,
                    DaysOff = request.DaysOff,
                    DailyData = request.DailyData.Select(x => new DailyDataModel
                    {
                        Day = x.Day,
                        ShiftData = x.ShiftData.Select(x => new ShiftDataModel
                        {
                            SiteName = x.SiteName,
                            StartTime = x.StartTime,
                            EndTime = x.EndTime,
                            ShiftHourTotal = x.ShiftHourTotal,
                            ShiftNotes = x.ShiftNotes
                        }).ToList()
                    }).ToList()

                };

                _context.Timesheets.Add(timesheet);

                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                throw new Exception("can not create");
            }
        }


    }

}
