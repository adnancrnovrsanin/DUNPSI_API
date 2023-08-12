using Application.SoftwareProjects;
using Domain.ModelsDTOs;
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

        [HttpPut("reject-request/{projectRequestId}")]
        public async Task<IActionResult> RejectRequest(Guid projectRequestId)
        {
            return HandleResult(await Mediator.Send(new RejectRequest.Command { ProjectRequestId = projectRequestId }));
        }

        [HttpPost("initial-request")]
        public async Task<IActionResult> InitialRequest(InitialProjectRequestDto initialProjectRequestDto)
        {
            return HandleResult(await Mediator.Send(new InitialRequest.Command { InitialProjectRequest = initialProjectRequestDto }));
        }
    }
}