using Microsoft.AspNetCore.Mvc;
using Web.Services.Customer;

namespace Web.Controllers.API
{
    public class CustomersController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Read.Query query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("findById/{id}")]
        public async Task<IActionResult> FindById([FromRoute] Find.Query query)
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
