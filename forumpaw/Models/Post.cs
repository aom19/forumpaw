using System.ComponentModel.DataAnnotations;

namespace forumpaw.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string ?Title { get; set; }
        public string ?Content { get; set; }
        public DateTime Created { get; set; }


       


    }
}
