namespace mycookbook.cc.MyCookBook.Ingredient.Repository
{
    interface IIngredientRepository
    {
        Ingredient Save(int loggedInUserId, Ingredient ingredient);
        Ingredient Find(int loggedInUserId, int ingredientId);
        IngredientSearchResult Search(int loggedInUserId, IngredientSearchQuery query);
        void Delete(Ingredient ingredient);
    }
}