using Application.ProjectManagers;
using Domain.ModelsDTOs;
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
    }
}