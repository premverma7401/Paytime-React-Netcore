// using System.Threading;
// using System.Threading.Tasks;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Paytime.Domain;
// using Paytime.Persistence;

// namespace Paytime.Application.UserTimesheet
// {
//     public class Details
//     {
//         public class Query : IRequest<WeeklyDataModel>
//         {

//         }
//         public class Handler : IRequestHandler<Query, WeeklyDataModel>
//         {
//             private readonly DataContext _context;
//             public Handler(DataContext context)
//             {
//                 _context = context;


//             }
//             public Task<WeeklyDataModel> Handle(Query request, CancellationToken cancellationToken)
//             {
//                var timesheets = _context.Timesheets.Include(x=>x.DailyData)
//             }
//         }


//     }
// }