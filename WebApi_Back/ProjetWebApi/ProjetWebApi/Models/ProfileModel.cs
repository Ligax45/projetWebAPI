using ProjetWebApi.Data.Entities;

namespace ProjetWebApi.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
