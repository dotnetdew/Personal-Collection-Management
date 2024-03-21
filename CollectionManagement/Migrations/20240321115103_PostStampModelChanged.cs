using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagement.Migrations
{
    /// <inheritdoc />
    public partial class PostStampModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "PostStamps",
                newName: "ImageMimeType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "PostStamps",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d0e6f1e-b7bf-42ac-8cba-de1771e07535", "AQAAAAIAAYagAAAAEG/eZ2O52ALBBeojHD53i1E6E0Y4ovaUNtcIdCSfGdydGoKFjY4e68hd973dhJWXLg==", "bc7ce8c5-9df7-4326-93d0-8504b8329b57" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aefff190-1de6-4d7e-a3cb-55fb639c87f1", "AQAAAAIAAYagAAAAED9hxkPfDo/Z0WZg1SYcC5Zn9kk1COMdIEmNgCWeiurAAg4NHj6kgIzUPWzReJ8SYw==", "8f3d7e87-625d-4c1c-a90a-97e03c9087d1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "PostStamps");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "PostStamps",
                newName: "ImageUrl");

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
    }
}
