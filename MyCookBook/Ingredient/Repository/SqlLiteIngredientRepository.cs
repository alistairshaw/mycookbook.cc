using System.Collections.Generic;
using System.Linq;
using mycookbook.cc.MyCookBook.Base;
using mycookbook.cc.MyCookBook.Base.Exceptions;
using mycookbook.cc.MyCookBook.Ingredient.Exceptions;
using mycookbook.cc.MyCookBook.Ingredient.Repository.Models;

namespace mycookbook.cc.MyCookBook.Ingredient.Repository
{
    class SqlLiteIngredientRepository : IIngredientRepository
    {
        public void Delete(Ingredient ingredient)
        {
            throw new System.NotImplementedException();
        }

        public Ingredient Find(int loggedInUserId, int ingredientId)
        {
            using (MyCookBookDb db = new MyCookBookDb())
            {
                IngredientModel existingIngredient = db.Ingredients.FirstOrDefault(i => i.Id == ingredientId && i.UserId == loggedInUserId);
                if (existingIngredient == null) throw new RecordNotFoundException();

                return IngredientFactory.FromDatabase(existingIngredient);
            }
        }

        public Ingredient Save(int loggedInUserId, Ingredient ingredient)
        {
            if (this.IsDuplicate(loggedInUserId, ingredient)) throw new DuplicateIngredientException("Ingredient already exists");

            using (MyCookBookDb db = new MyCookBookDb())
            {
                IngredientModel ingredientModel = ingredient.DatabaseView();
                ingredientModel.UserId = loggedInUserId;

                db.Ingredients.Add(ingredientModel);
                db.SaveChanges();

                var id = ingredientModel.Id.GetValueOrDefault();

                return this.Find(loggedInUserId, id);
            }
        }

        public IngredientSearchResult Search(int loggedInUserId, IngredientSearchQuery query)
        {
            using (MyCookBookDb db = new MyCookBookDb())
            {
                var dbQuery = db.Ingredients
                .Where(i => i.UserId == loggedInUserId)
                .Take(query.Limit)
                .Skip(query.Offset);

                IngredientModel[] results = dbQuery.ToArray();
                var result = new IngredientSearchResult();
                result.Ingredients = results.Select(i => IngredientFactory.FromDatabase(i)).ToArray();
                result.Total = dbQuery.Count();
                result.Limit = query.Limit;
                result.Offset = query.Offset;

                return result;
            }
        }

        private bool IsDuplicate(int loggedInUserId, Ingredient ingredient)
        {
            using (MyCookBookDb db = new MyCookBookDb())
            {
                IngredientModel existingIngredient = db.Ingredients.FirstOrDefault(i => i.Title == ingredient.Title() && i.UserId == loggedInUserId);
                if (existingIngredient == null) return false;

                return true;
            }
        }
    }
}