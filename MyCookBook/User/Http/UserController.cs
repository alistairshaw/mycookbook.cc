using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using mycookbook.cc.MyCookBook.Base;
using mycookbook.cc.MyCookBook.Base.Exceptions;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.User.Aggregates;
using mycookbook.cc.MyCookBook.User.Exceptions;
using mycookbook.cc.MyCookBook.User.Repository;

namespace mycookbook.cc.MyCookBook.User.Http
{
    [ApiController]
    public class UserController : BaseController
    {
        private IUserRepository _userRepository;

        public UserController(IServiceProvider serviceProvider)
        {
            _userRepository = serviceProvider.GetService<IUserRepository>();
        }

        [HttpPost]
        [Route("api/auth/register")]
        public IActionResult Register()
        {
            try
            {
                var authResult = _userRepository.Register(
                    UserFactory.FromRegistrationForm(
                        Request.Form["email"],
                        Request.Form["name"]
                    ),
                    UserPassword.FromPlainText(Request.Form["password"])
                    );
                return Json(authResult);
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
                var authResult = _userRepository.SignIn(emailAddress, Request.Form["password"]);

                return Json(authResult);
            }
            catch (System.ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Json(JsonErrorResponse.FromMessage(ex.Message));
            }
            catch (RecordNotFoundException)
            {
                Response.StatusCode = 403;
                return Json(JsonErrorResponse.FromMessage("Incorrect Email or Password"));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/auth/sign-out")]
        public IActionResult SignOut()
        {
            try
            {
                _userRepository.SignOut(Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                return Json(true);
            }
            catch (FormatException)
            {
                Response.StatusCode = 401;
                return Json(JsonErrorResponse.FromMessage("Permission Denied"));
            }
        }
    }
}