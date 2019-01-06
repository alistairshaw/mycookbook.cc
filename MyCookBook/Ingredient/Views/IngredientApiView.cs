namespace mycookbook.cc.MyCookBook.Ingredient.Views
{
    public class IngredientApiView
    {
        public int? Id;
        public string Title;
        public string Blurb;
    
        public IngredientApiView(int? id, string title, string blurb)
        {
            Id = id;
            Title = title;
            Blurb = blurb;
        }
    }
}