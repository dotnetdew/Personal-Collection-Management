using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CollectionManagement.Migrations
{
    /// <inheritdoc />
    public partial class twoRolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de", null, "Admin", null },
                    { "d47b3c1e-1310-409d-b893-0a662a64c35d", null, "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de", 0, "1a0d5413-7340-4c88-8d42-5e525e895ca4", "AppUser", "admin@admin.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEDz7EDmb8ZaLYvzUUkOSQ25dLwi3Wa+hc1wM8poZ55P6Qd8nfWpfW+UkUrWxD5xoDg==", null, false, "9d8310e5-7855-435e-ae2b-46eec4660eda", false, "admin@admin.com" },
                    { "d47b3c1e-1310-409d-b893-0a662a64c35d", 0, "c8148c3b-8f84-4d02-ba29-9f4219d5f51d", "AppUser", "user@user.com", false, false, null, null, null, "AQAAAAIAAYagAAAAECYcjUFFSqB00FFbah4MKYDpmP+by18ulFdoFgNLAPA7/v4v+6bQGLKqzhH0iZx7Gg==", null, false, "fc2a213e-6393-4d8c-90dd-1ca5d54b54b0", false, "user@user.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de", "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de" },
                    { "d47b3c1e-1310-409d-b893-0a662a64c35d", "d47b3c1e-1310-409d-b893-0a662a64c35d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de", "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d47b3c1e-1310-409d-b893-0a662a64c35d", "d47b3c1e-1310-409d-b893-0a662a64c35d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d");
        }
    }
}
