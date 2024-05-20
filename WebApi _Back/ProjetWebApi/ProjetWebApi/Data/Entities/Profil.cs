using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebApi.Data.Entities
{
    [Table("profil")]
    public class Profil
    {
        [Key, Required]
        public int id { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
    }
}
