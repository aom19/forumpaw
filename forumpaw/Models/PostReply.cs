using System.ComponentModel.DataAnnotations;
namespace forumpaw.Models
{
    public class PostReply
    {
        [Key]
        public int Id { get; set; }
        public string ?Content { get; set; }

        public DateTime Created { get; set; }

        public virtual Post Post { get; set; }
        public virtual IEnumerable<PostReply> postreply { get; set; }
    }
}
