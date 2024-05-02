using Microsoft.AspNetCore.Identity;


namespace AutoService.Domain.Entities.Models.UserModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
