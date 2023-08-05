using Application.SoftwareProjects;
using Domain.ModelsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SoftwareProjectController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(SoftwareProjectDto softwareProjectDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { SoftwareProject = softwareProjectDto }));
        }
    }
}