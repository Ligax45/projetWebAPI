using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebApi.Data.Entities
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        [Key, Required]
<<<<<<< HEAD
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Salt {  get; set; }
=======
        public int id { get; set; }
        public string email { get; set; } = string.Empty;
        public string mdp { get; set; } = string.Empty;
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
    }
}
