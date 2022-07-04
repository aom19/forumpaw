using Microsoft.EntityFrameworkCore;
using forumpaw.Models;
namespace forumpaw.Models
{
    public class ForumContext:DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options) { }
        public DbSet<Forum> ?Forums { get; set; }
        public DbSet<User> ?Users { get; set; }
        public DbSet<Post> ?Posts { get; set; }  

        public DbSet<PostReply> PostReply{ get; set; }


    }
}
