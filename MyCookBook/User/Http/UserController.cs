using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Exceptions;
using mycookbook.cc.MyCookBook.User.Repository;

namespace mycookbook.cc.MyCookBook.User.Http
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "user1", "user2" };
        }
    }

    [Route("api/auth/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private IUserRepository UserRepository;

        public RegisterController(IServiceProvider serviceProvider)
        {
            this.UserRepository = serviceProvider.GetService<IUserRepository>();
        }

        // POST api/auth/register
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                var user = this.UserRepository.Register(
                    UserFactory.FromRegistrationForm(
                        Request.Form["email"],
                        Request.Form["name"]
                    ),
                    UserPassword.FromPlainText(Request.Form["password"])
                    );
                return Json(user.ApiView());
            }
            catch (System.ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Json(JsonErrorResponse.FromMessage(ex.Message));
            }
            catch (DuplicateUserException ex)
            {
                Response.StatusCode = 403;
                return Json(JsonErrorResponse.FromMessage(ex.Message));
            }
        }
    }
}