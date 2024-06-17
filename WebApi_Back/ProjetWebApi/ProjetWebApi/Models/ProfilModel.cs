using ProjetWebApi.Data.Entities;

namespace ProjetWebApi.Models
{
    public class ProfilModel
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
