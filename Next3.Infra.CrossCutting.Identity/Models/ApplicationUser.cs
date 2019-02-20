using Microsoft.AspNetCore.Identity;

namespace MyProject.Infra.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
