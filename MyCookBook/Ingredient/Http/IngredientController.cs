using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using mycookbook.cc.MyCookBook.Base;
using mycookbook.cc.MyCookBook.Base.ValueObjects;
using mycookbook.cc.MyCookBook.Ingredient.Exceptions;
using mycookbook.cc.MyCookBook.Ingredient.Repository;

namespace mycookbook.cc.MyCookBook.Ingredient.Http
{
    [ApiController]
    public class IngredientController : BaseController
    {
        private IIngredientRepository _ingredientRepository;

        public IngredientController(IServiceProvider serviceProvider)
        {
            _ingredientRepository = serviceProvider.GetService<IIngredientRepository>();
        }

        [Authorize]
        [HttpPost]
        [Route("api/ingredient/create")]
        public IActionResult Create()
        {
            try
            {
                int userId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var ingredient = IngredientFactory.FromApi(Request.Form["title"], Request.Form["blurb"], null);
                ingredient = _ingredientRepository.Save(userId, ingredient);
                return Json(ingredient.ApiView());
            }
            catch (DuplicateIngredientException ex)
            {
                Response.StatusCode = 400;
                return Json(JsonErrorResponse.FromMessage(ex.Message));
            }
        }
    }
}