namespace mycookbook.cc.MyCookBook.Ingredient.Repository
{
    class IngredientSearchQuery
    {
        public string Filter;
        public int Offset;
        public int Limit;
        private IngredientSearchQuery(string filter, int offset, int limit)
        {
            Filter = filter;
            Offset = offset;
            Limit = limit;
        }

        public static IngredientSearchQuery FromFilter(string filter)
        {
            return new IngredientSearchQuery(filter, 0, 5000);
        }
    }
}