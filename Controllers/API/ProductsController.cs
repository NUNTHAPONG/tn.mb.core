using Microsoft.AspNetCore.Mvc;
using Web.Services.Product;

namespace Web.Controllers.API
{
    public class ProductsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Read.Query query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Create.Command model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Update.Command model)
        {
            return Ok(await Mediator.Send(model));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Delete.Command model)
        {
            return Ok(await Mediator.Send(model));
        }
    }
}
