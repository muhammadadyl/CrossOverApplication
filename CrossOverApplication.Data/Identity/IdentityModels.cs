using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CrossOverApplication.Data.Identity
{
    // You can add profile data for the user by adding more properties to your ApplicationIdentityUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationIdentityUser 
        : IdentityUser<string, ApplicationIdentityUserClaim, ApplicationIdentityUserRole, ApplicationIdentityUserLogin>
    {
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