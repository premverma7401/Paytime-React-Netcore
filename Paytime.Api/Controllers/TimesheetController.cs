using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paytime.Application.Interfaces;
using Paytime.Application.Timesheets;
using Paytime.Domain.models.viewModels;

namespace Paytime.Api.Controllers
{
    [AllowAnonymous]

    public class TimesheetController : BaseController
    {
        private readonly IUserAccessor _currentUserService;

        public TimesheetController(IUserAccessor currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }


        [HttpGet("summary")]
        /// <summary>
        /// First API call after user logged in. This is basically showing card for summary data of TS.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<SummaryCardViewModel>>> Summary()
        {
            return await Mediator.Send(new TimesheetSummary.Query());
        }

        [HttpGet("summary/{id}/detail")]
        /// <summary>
        /// Second API call when user click on the summary card, Detailed view for that ID passed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<List<DetailCardViewModel>>> TimesheetDetail(Guid id)
        {
            return await Mediator.Send(new TimesheetDetail.Query { Id = id });
        }

        [HttpGet("{username}")]
        /// <summary>
        /// Last submitted timesheet of the user, based on current user logged in.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<ActionResult<DetailLastTsSubmitted>> Detail(string username)
        {
            return await Mediator.Send(new TimesheetLastSubmitted.Query { Username = username });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }


    }
}
