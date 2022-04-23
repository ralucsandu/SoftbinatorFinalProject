using Microsoft.AspNetCore.Identity;

namespace FinalProject.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        public UserRole() : base() { }
        public override string UserId { get; set; }
        public virtual User User { get; set; }
        public override string RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}