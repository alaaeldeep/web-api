using Microsoft.AspNetCore.Identity;

namespace Day3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FavouriteColor { get; set; } = string.Empty;
    }
}
