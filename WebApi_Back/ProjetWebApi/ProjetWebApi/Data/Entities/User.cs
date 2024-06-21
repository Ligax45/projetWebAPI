using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebApi.Data.Entities
{
    [Table("user")]
    public class User
    {
        [Key, Required]
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Salt {  get; set; }
    }
}
