using System.ComponentModel.DataAnnotations;

namespace mycookbook.cc.MyCookBook.Ingredient.Repository.Models
{
    public class IngredientModel
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
    }
}