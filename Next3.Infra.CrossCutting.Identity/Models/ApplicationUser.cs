using Microsoft.AspNetCore.Identity;

namespace Next3.Infra.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
