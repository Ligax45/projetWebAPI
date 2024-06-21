using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetWebApi.Data.Entities
{
    [Table ("post")]
    public class Post
    {
        [Key, Required]
        public int Id { get; set; }
        public virtual Profile Profile { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date {  get; set; }
    }
}
