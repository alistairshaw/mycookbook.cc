using System.ComponentModel.DataAnnotations;

namespace mycookbook.cc.MyCookBook.User.Repository
{
    public class UserModel
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Email { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public string Blurb { get; set; }
        public string Password { get; set; }
    }
}