using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mycookbook.cc.MyCookBook.User.Repository.Models
{
    public class UserTokenModel
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [MaxLength(20)]
        public int UserId { get; set; }
        public string Token { get; set; }
        [Column(TypeName = "datetime")]
        public string Created { get; set; }
        [Column(TypeName = "datetime")]
        public string Expires { get; set; }
    }
}