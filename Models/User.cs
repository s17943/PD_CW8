using System.ComponentModel.DataAnnotations;

namespace CW_PD8.Models
{
    public class User
    {
        public Guid Token { get; set; }
        [Key]
        public string Login { get; set; }
        public string UserPassword { get; set; }
        public DateTime TokenTime { get; set; }
        public DateTime Expiration { get; set; }
        
    }
}
