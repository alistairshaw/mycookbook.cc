namespace mycookbook.cc.MyCookBook.Ingredient.Repository
{
    class IngredientSearchQuery
    {
        private string filter;
        private int offset;
        private int limit;
        private IngredientSearchQuery(string filter, int offset, int limit)
        {
            this.filter = filter;
            this.offset = offset;
            this.limit = limit;
        }

        public IngredientSearchQuery FromFilter(string filter)
        {
            return new IngredientSearchQuery(filter, 0, 50);
        }
    }
}