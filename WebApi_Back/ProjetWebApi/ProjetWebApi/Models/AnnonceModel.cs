using ProjetWebApi.Data.Entities;

namespace ProjetWebApi.Models
{
    public class AnnonceModel
    {
        public int Id { get; set; }
        public int ProfilId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
