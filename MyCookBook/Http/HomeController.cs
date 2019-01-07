using Microsoft.AspNetCore.Mvc;

namespace mycookbook.cc.MyCookBook.Http
{
    [Controller]
    public class UserController : BaseController
    {
        [HttpGet]
        [Route("{*url}")]
        public IActionResult Test()
        {
            return View("~/Resources/Views/Index.cshtml");
        }
    }
}