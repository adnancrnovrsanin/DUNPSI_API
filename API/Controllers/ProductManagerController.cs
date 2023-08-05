using Application.ProductManagers;
using Domain.ModelsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductManagerController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(ProductManagerDto productManagerDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ProductManager = productManagerDto }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductManager(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
    }
}