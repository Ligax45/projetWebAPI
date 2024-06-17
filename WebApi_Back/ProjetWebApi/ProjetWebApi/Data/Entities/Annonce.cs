using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebApi.Data.Entities
{
    [Table ("annonce")]
    public class Annonce
    {
        [Key, Required]
        public int Id { get; set; }
        public virtual Profil Profil { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date {  get; set; }
    }
}
