using System;
using System.Collections.Generic;

namespace AwesomeDemoDB.Data
{
    public partial class Users
    {
        public Users()
        {
            Enemies = new HashSet<Enemies>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        // Lazy loading
        public virtual ICollection<Enemies> Enemies { get; set; }
    }
}
