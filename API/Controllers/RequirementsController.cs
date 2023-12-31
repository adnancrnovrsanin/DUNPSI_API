using Application.Requirements;
using Application.SoftwareProjects.DTOs;
using Domain.ModelsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RequirementsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetRequirements()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{appUserId}")]
        public async Task<IActionResult> GetRequirementsByAppUserId(string appUserId)
        {
            return HandleResult(await Mediator.Send(new ListByUser.Query { AppUserId = appUserId }));
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetRequirementsByProjectId(Guid projectId)
        {
            return HandleResult(await Mediator.Send(new ListByProject.Query { ProjectId = projectId }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequirement(RequirementDto requirementDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Requirement = requirementDto }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequirement(RequirementDto requirementDto)
        {
            return HandleResult(await Mediator.Send(new Update.Command { Requirement = requirementDto }));
        }

        [HttpPut("developer-assignment")]
        public async Task<IActionResult> AssignDeveloperToRequirement(RequirementDto requirementDto)
        {
            return HandleResult(await Mediator.Send(new AssignDevelopers.Command { Requirement = requirementDto }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequirement(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPut("{id}/status/{status}")]
        public async Task<IActionResult> UpdateRequirementStatus(Guid id, string status)
        {
            return HandleResult(await Mediator.Send(new UpdateStatus.Command { Id = id, Status = status }));
        }
    }
}