using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace CollectionManagement.Models;

public class AppUser : IdentityUser
{
    public virtual ICollection<MyCollection> Collections { get; set; }
    [DisplayName("IsBlocked")]
    public bool IsBlocked { get; set; }
}