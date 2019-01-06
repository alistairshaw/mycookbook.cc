using System;

namespace mycookbook.cc.MyCookBook.Ingredient.Exceptions
{
    class DuplicateIngredientException : Exception
    {
        public DuplicateIngredientException()
        {
        }

        public DuplicateIngredientException(string message)
            : base(message)
        {
        }

        public DuplicateIngredientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}