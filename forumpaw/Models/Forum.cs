using System.ComponentModel.DataAnnotations;

namespace forumpaw.Models
{
    public class Forum
    {
        [Key]
        public int ID { get; set; }
        public string ?Title { get; set; }
        public string ?Description { get; set; }
        public DateTime Created { get; set; }
        public string ?ImageUrl { get; set; }

        public virtual IEnumerable <Post> Posts { get; set; }
    }
}
