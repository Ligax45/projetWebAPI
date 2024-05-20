using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebApi.Data.Entities
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        [Key, Required]
        public int id { get; set; }
        public string email { get; set; }
        public string mdp { get; set; }
        public int age { get; set; }
    }
}
