using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FS0924_S19_L1.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        // navigazione
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
