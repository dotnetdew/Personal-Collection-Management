using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionManagement.Migrations
{
    /// <inheritdoc />
    public partial class LazyLoadingEnabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80091b98-79dd-4d25-ab4c-9c3e5dac3bf7", "AQAAAAIAAYagAAAAEK2VDL2EZCEmnPQNtVD/lkxTRvk0MgVrdUsPX9UeP32xm/ibRQYd5q7+1qflnJCpqA==", "feb7874f-7196-40ed-ab4a-bbb0be1b81be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f7b31e2-dcde-41dc-a59e-2abddc9d1d4d", "AQAAAAIAAYagAAAAEOO5bsndhvEM0Vio8gvyWxk6KW/nUwKC3vro0R9KZPDsCvSmLgbw7n5BkkcS2IjfKQ==", "e13c6403-9d07-4005-9335-c8c4c2583285" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a535a8f-dccf-4a1d-a25d-d9c3bb4803de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a0d5413-7340-4c88-8d42-5e525e895ca4", "AQAAAAIAAYagAAAAEDz7EDmb8ZaLYvzUUkOSQ25dLwi3Wa+hc1wM8poZ55P6Qd8nfWpfW+UkUrWxD5xoDg==", "9d8310e5-7855-435e-ae2b-46eec4660eda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d47b3c1e-1310-409d-b893-0a662a64c35d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8148c3b-8f84-4d02-ba29-9f4219d5f51d", "AQAAAAIAAYagAAAAECYcjUFFSqB00FFbah4MKYDpmP+by18ulFdoFgNLAPA7/v4v+6bQGLKqzhH0iZx7Gg==", "fc2a213e-6393-4d8c-90dd-1ca5d54b54b0" });
        }
    }
}
