using Microsoft.AspNetCore.Identity;

namespace CollectionManagement.Models;

public class AppUser : IdentityUser
{
    public virtual ICollection<MyCollection> Collections { get; set; }
}