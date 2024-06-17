using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebApi.Data.Entities
{
    [Table("profil")]
    public class Profil
    {
        [Key, Required]
        public int Id { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
    }
}
