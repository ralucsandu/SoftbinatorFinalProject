using Microsoft.AspNetCore.Identity;

namespace FinalProject.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}