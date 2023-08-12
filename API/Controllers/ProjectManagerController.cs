using Application.ProjectManagers;
using Domain.ModelsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProjectManagerController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(ProjectManagerDto projectManagerDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ProjectManager = projectManagerDto }));
        }

        [HttpGet("{appUserId}")]
        public async Task<IActionResult> Get(string appUserId)
        {
            return HandleResult(await Mediator.Send(new Details.Query { AppUserId = appUserId }));
        }
    }
}