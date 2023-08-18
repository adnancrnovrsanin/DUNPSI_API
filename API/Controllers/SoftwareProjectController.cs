using Application.SoftwareProjects;
using Application.SoftwareProjects.DTOs;
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

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProject(Guid projectId)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = projectId }));
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

        [HttpGet("project-requests")]
        public async Task<IActionResult> GetProjectRequests()
        {
            return HandleResult(await Mediator.Send(new ListProjectRequests.Query()));
        }

        [HttpGet("project-requests/{projectRequestId}")]
        public async Task<IActionResult> GetProjectRequest(Guid projectRequestId)
        {
            return HandleResult(await Mediator.Send(new GetProjectRequest.Query { ProjectRequestId = projectRequestId }));
        }

        [HttpGet("project-phases/{projectId}")]
        public async Task<IActionResult> GetProjectPhases(Guid projectId)
        {
            return HandleResult(await Mediator.Send(new ListProjectPhases.Query { ProjectId = projectId }));
        }

        [HttpPut("project-phases/requirement-layout")]
        public async Task<IActionResult> UpdateRequirementLayout(UpdateRequirementLayoutDto updateRequirementLayoutDto)
        {
            return HandleResult(await Mediator.Send(new UpdateRequirementLayout.Command { UpdateRequest = updateRequirementLayoutDto }));
        }
    }
}