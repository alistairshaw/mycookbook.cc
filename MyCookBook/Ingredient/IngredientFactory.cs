using mycookbook.cc.MyCookBook.Ingredient.Repository.Models;

namespace mycookbook.cc.MyCookBook.Ingredient
{
    class IngredientFactory
    {
        public static Ingredient FromApi(string title, string blurb, int? id)
        {
            return new Ingredient(id, title, blurb);
        }

        public static Ingredient FromDatabase(IngredientModel ingredientModel)
        {
            return new Ingredient(ingredientModel.Id, ingredientModel.Title, ingredientModel.Blurb);
        }
    }
}