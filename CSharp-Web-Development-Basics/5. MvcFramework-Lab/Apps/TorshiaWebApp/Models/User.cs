using System.Collections.Generic;

namespace TorshiaWebApp.Models
{
    public class User : BaseEntity<int>
    {
        public User()
        {
            this.Reports = new HashSet<Report>();    
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
