using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace CollectionManagement.Models;

public class AppUser : IdentityUser
{
    public virtual ICollection<MyCollection> Collections { get; set; }
}