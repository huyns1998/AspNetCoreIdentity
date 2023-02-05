using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
