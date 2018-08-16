using System;
using System.Collections.Generic;

namespace AwesomeDemoDB.Data
{
    public partial class Enemies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User { get; set; }

        public Users UserNavigation { get; set; }
    }
}
