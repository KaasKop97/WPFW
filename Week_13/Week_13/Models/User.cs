using Microsoft.AspNetCore.Identity;

namespace Week_13.Models
{
    public class User : IdentityUser
    {
        public string isTeacher { get; set; } 
    }
}