using Microsoft.AspNetCore.Identity;

namespace Evona.Task.Identity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
