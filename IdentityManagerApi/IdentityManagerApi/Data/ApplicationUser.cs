using Microsoft.AspNetCore.Identity;

namespace IdentityManagerApi.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
