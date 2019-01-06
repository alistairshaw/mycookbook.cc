using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using mycookbook.cc.MyCookBook.Base.Exceptions;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Exceptions;
using mycookbook.cc.MyCookBook.User.Repository;

namespace mycookbook.cc.MyCookBook.User.Http
{
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository UserRepository;

        public UserController(IServiceProvider serviceProvider)
        {
            this.UserRepository = serviceProvider.GetService<IUserRepository>();
        }

        [HttpPost]
        [Route("api/auth/register")]
        public IActionResult Register()
        {
            try
            {
                var token = this.UserRepository.Register(
                    UserFactory.FromRegistrationForm(
                        Request.Form["email"],
                        Request.Form["name"]
                    ),
                    UserPassword.FromPlainText(Request.Form["password"])
                    );
                return Json(token);
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

        [HttpPost]
        [Route("api/auth/sign-in")]
        public IActionResult SignIn()
        {
            try
            {
                var emailAddress = EmailAddress.FromString(Request.Form["email"]);
                var token = this.UserRepository.SignIn(emailAddress, Request.Form["password"]);

                return Json(token);
            }
            catch (System.ArgumentException ex)
            {
                return Json(JsonErrorResponse.FromMessage(ex.Message));
            }
            catch (RecordNotFoundException)
            {
                return Json(JsonErrorResponse.FromMessage("Incorrect Email or Password"));
            }
        }
    }
}