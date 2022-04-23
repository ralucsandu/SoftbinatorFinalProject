using Microsoft.AspNetCore.Identity;

namespace FinalProject.Entities
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}