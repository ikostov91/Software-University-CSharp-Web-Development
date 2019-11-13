using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Panda.Models
{
    public class User : IdentityUser
    {
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }

        public override string Email { get => base.Email; set => base.Email = value; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
