using ProjetWebApi.Data.Entities;

namespace ProjetWebApi.Models
{
    public class ProfilModel
    {
        public int id { get; set; }
        public int utilisateurId { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
    }
}
