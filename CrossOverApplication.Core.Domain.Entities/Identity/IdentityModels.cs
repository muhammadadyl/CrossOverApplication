using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CrossOverApplication.Core.Domain.Entities.Identity
{
    // You can add profile data for the user by adding more properties to your ApplicationIdentityUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationIdentityUser
        : IdentityUser<string, ApplicationIdentityUserClaim, ApplicationIdentityUserRole, ApplicationIdentityUserLogin>
    {
        public ApplicationIdentityUser()
        {
            Claims = new List<ApplicationUserClaim>();
            Roles = new List<ApplicationUserRole>();
            Logins = new List<ApplicationUserLogin>();
        }
        public virtual int AccessFailedCount { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; private set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual int Id { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; private set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual ICollection<ApplicationUserRole> Roles { get; private set; }
        public virtual string SecurityStamp { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual string UserName { get; set; }
    }


    public class ApplicationIdentityRole : IdentityRole<string, ApplicationIdentityUserRole, ApplicationIdentityRoleClaim>
    {
        public ApplicationIdentityRole()
        {
        }

        public ApplicationIdentityRole(string name)
        {
            Name = name;
        }
    }

    public class ApplicationIdentityUserRole : IdentityUserRole<string>
    {
    }

    public class ApplicationIdentityUserClaim : IdentityUserClaim<string>
    {
    }

    public class ApplicationIdentityUserLogin : IdentityUserLogin<string>
    {
    }

    public class ApplicationIdentityRoleClaim : IdentityRoleClaim<string>
    {
    }

    public class ApplicationIdentityUserToken : IdentityUserToken<string>
    {

    }

}