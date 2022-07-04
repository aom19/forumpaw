

using System.ComponentModel.DataAnnotations;

namespace forumpaw.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; } 
        public string ?userName { get; set; }
        public string ?password { get; set; }        
        public string ?email { get; set; }
       
        public string ?Name { get; set; }
        public int Age { get; set; }
        public string ?Interes { get; set; }
        public IEnumerable<Forum> Forums { get; set; }



    }
 

}
