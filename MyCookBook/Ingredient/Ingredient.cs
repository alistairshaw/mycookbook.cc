using System;
using mycookbook.cc.MyCookBook.Ingredient.Repository.Models;
using mycookbook.cc.MyCookBook.Ingredient.Views;

namespace mycookbook.cc.MyCookBook.Ingredient
{
    class Ingredient
    {
        private int? id;
        private string title;
        private string blurb;

        public Ingredient(int? id, string title, string blurb)
        {
            this.id = id;
            this.title = title;
            this.blurb = blurb;
        }

        public string Title()
        {
            return this.title;
        }

        internal Ingredient Update(string title, string blurb)
        {
            this.title = title;
            this.blurb = blurb;
            return this;
        }

        public IngredientApiView ApiView()
        {
            return new IngredientApiView(this.id, this.title, this.blurb);
        }

        public IngredientModel DatabaseView()
        {
            IngredientModel ingredientModel = new IngredientModel();
            ingredientModel.Id = this.id;
            ingredientModel.Title = this.title;
            ingredientModel.Blurb = this.blurb;
            return ingredientModel;
        }
    }
}