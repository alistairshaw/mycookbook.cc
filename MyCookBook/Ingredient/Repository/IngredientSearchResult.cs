using System.Linq;
using mycookbook.cc.MyCookBook.Ingredient.Views;

namespace mycookbook.cc.MyCookBook.Ingredient.Repository
{
    class IngredientSearchResult
    {
        public Ingredient[] Ingredients { get; set; }
        public int Total { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }

        public struct IngredientSearchResultApiView {
            public IngredientApiView[] Ingredients { get; set; }
            public int Total { get; set; }
            public int Offset { get; set; }
            public int Limit { get; set; }
            
            public IngredientSearchResultApiView(IngredientApiView[] ingredients, int total, int offset, int limit)
            {
                Ingredients = ingredients;
                Total = total;
                Offset = offset;
                Limit = limit;
            }
        }

        public IngredientSearchResultApiView ApiView()
        {
            var ing = Ingredients.Select(i => i.ApiView()).ToArray();
            return new IngredientSearchResultApiView(ing, Total, Offset, Limit);
        }
    }
}