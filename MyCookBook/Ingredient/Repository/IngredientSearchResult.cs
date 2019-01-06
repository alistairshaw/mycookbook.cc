namespace mycookbook.cc.MyCookBook.Ingredient.Repository
{
    class IngredientSearchResult
    {
        public Ingredient[] Ingredients { get; set; }
        public int Total { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}