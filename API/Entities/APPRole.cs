using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class APPRole : IdentityRole<int>
    {
        public ICollection<APPUserRole> UserRoles { get; set; }
        
    }
}