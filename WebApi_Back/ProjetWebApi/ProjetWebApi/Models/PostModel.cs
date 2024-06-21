using ProjetWebApi.Data.Entities;

namespace ProjetWebApi.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
