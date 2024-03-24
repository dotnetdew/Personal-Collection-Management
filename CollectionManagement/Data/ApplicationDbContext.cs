using CollectionManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<PostStamp> PostStamps { get; set; }
        public DbSet<MyCollection> Collection { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRole = new IdentityRole { Id = "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de", Name = "Admin" };
            var userRole = new IdentityRole { Id = "d47b3c1e-1310-409d-b893-0a662a64c35d", Name = "User" };

            builder.Entity<IdentityRole>().HasData(
                adminRole,
                userRole
            );

            var hasher = new PasswordHasher<AppUser>();

            var adminUser = new AppUser()
            {
                Id = "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                UserName = "admin@admin.com",
                Email = "admin@admin.com"
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin123");

            var userUser = new AppUser
            {
                Id = "d47b3c1e-1310-409d-b893-0a662a64c35d",
                UserName = "user@user.com",
                Email = "user@user.com"
            };
            userUser.PasswordHash = hasher.HashPassword(userUser, "user1234");

            // Add users and roles
            builder.Entity<AppUser>().HasData(
                adminUser,
                userUser
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = adminRole.Id },
                new IdentityUserRole<string> { UserId = userUser.Id, RoleId = userRole.Id }
            );
        }
    }
}