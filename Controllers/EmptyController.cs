using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class EmptyController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            return NotFound("Server started, api/{controller}/{action}");
        }

    }
}
