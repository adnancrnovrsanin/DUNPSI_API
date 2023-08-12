using Application.SoftwareProjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SoftwareProjectController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateDto projectCreateDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { SoftwareProject = projectCreateDto }));
        }
    }
}