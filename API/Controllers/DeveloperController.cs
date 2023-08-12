using Application.Developers;
using Domain.ModelsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DeveloperController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(DeveloperDto developerDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Developer = developerDto }));
        }

        [HttpGet("{appUserId}")]
        public async Task<IActionResult> Get(string appUserId)
        {
            return HandleResult(await Mediator.Send(new Details.Query { AppUserId = appUserId }));
        }
    }
}