using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagement.Migrations
{
    /// <inheritdoc />
    public partial class PropertyAddedAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "IsBlocked", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9599dbd5-946d-4135-a39f-56a8770c464f", false, "AQAAAAIAAYagAAAAEEnPhjjRKjTWmkQI41nzc9mjzWjattLbWq0AJHdc+QENf1uKqTC54YuMdZbFfeqyRg==", "794d60ee-3a63-4475-9ff1-96adbc411e4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "IsBlocked", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b409ac7b-147f-4523-9890-930a72b1a958", false, "AQAAAAIAAYagAAAAEIW3zJ1ApgVKISBLPhU4m4jD2vkIW7kA8zY3bFgtQSXjqAoaKrYe3Kmheu/uY1kRKw==", "22dffe3d-1bca-4e8e-aaf6-a0088e2839dc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "273ce22f-70fb-4feb-9a2b-439d656b0480", "AQAAAAIAAYagAAAAEMwXz6WDxJsOheHZ98IkzvwqXUEVBo03KAQzWV3BNEXmYld9Sk7suJBaruNLGXZIEw==", "5c3feb56-c1b8-42a4-a5c5-df411a5b55e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "156a688d-e519-46b1-841f-581324425ebf", "AQAAAAIAAYagAAAAEDnfiEBTAvb1Setpkb8QP2r/PKFJ+Qy5xcT6jLiNcUaBQvpR+wS9C6+M138eMtcHcw==", "b1321be0-0127-4234-9c6d-032cd6bc1675" });
        }
    }
}
