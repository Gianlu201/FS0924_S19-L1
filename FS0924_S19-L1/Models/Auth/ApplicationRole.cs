using Microsoft.AspNetCore.Identity;

namespace FS0924_S19_L1.Models.Auth
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
