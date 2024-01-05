using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class APPUserRole : IdentityUserRole<int>
    {
        public APPUser User { get; set; }
        public APPRole Role { get; set; }
    }
}