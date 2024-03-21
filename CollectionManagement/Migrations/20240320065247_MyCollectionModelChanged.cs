using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagement.Migrations
{
    /// <inheritdoc />
    public partial class MyCollectionModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Collection",
                newName: "ImageMimeType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Collection",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5428f8b-0bbe-43c5-afa8-f94b4731fc5b", "AQAAAAIAAYagAAAAEKvkzbG9svkx7gRXmss1jS6liZojM80QveqMSHccrqwc0EXRi/w/72SZTvyq9VCvTg==", "a0752ae0-f727-4cc9-b306-6b7952d34a58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dac3d60d-a7ed-4ad6-a2c5-b03875b7eeeb", "AQAAAAIAAYagAAAAEMdch1OB8+nz21uSbV8pfXoWvJTYTvAk7YhxXOG+ZUbJARiG8RZq6KR9evzk40eNJg==", "8c115f26-48a4-4e3c-8e47-0c26e9395567" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Collection");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "Collection",
                newName: "ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "936ec79e-26eb-43be-88e1-8864abad200f", "AQAAAAIAAYagAAAAEAGeWtTJExUMDpUZ5Z2i4P0KNVv5hTg3InlPp4j19vD1muyJV+W2iR2/bNyZW6+mVw==", "ee252ca3-3558-4a1a-8f98-255b49695d50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66516c7a-64c2-4372-ad18-d7cdce8f3b74", "AQAAAAIAAYagAAAAEJFxTkbK31WcrAsLuTOHUrObbGmj8r4fczt9GR3O7OEW7VF3tWEx9zFxzGUVD9LCoA==", "a1051060-b20b-4f37-90b1-2afb20d948ed" });
        }
    }
}
