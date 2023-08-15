using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class seededDefaultUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "207d3c67-4914-4cc7-8e18-00d4c786adc5", "fd983285-11fd-4858-8bb5-0548342e13da", "Administrator", "ADMINISTRATOR" },
                    { "78713bd4-00af-4a34-97f7-c2953203208b", "66a12394-0dae-4136-a5ec-b4c1853d0792", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "906a695a-cf80-4320-8ca0-ee1c12270618", 0, "08e97623-95b0-4b09-a9f8-dcfed7ce0391", "user@bookstore.com", false, "Systerm", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEAAzekP4S/Kqqpi5JjP6baghoYv/VT0CISFePSJ483bRXozHshjg8i49XPkLnHCmdw==", null, false, "989dea14-74ec-4245-8779-4f8db1eeafe3", false, "user@bookstore.com" },
                    { "f42d0bcc-b2f7-4900-a4c1-3507976f9166", 0, "4c00c03b-aa00-4f00-af7c-aed5df12c150", "admin@bookstore.com", false, "Systerm", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAELZqDG1wX0GfIyNmSFl0uEaNq3Bc/yl1oNZAMeqYK13pRzw943Z0pjbrOw/n/qCMbg==", null, false, "36a543fa-c2bf-442c-b3b6-b00c190674af", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "78713bd4-00af-4a34-97f7-c2953203208b", "906a695a-cf80-4320-8ca0-ee1c12270618" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "207d3c67-4914-4cc7-8e18-00d4c786adc5", "f42d0bcc-b2f7-4900-a4c1-3507976f9166" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "78713bd4-00af-4a34-97f7-c2953203208b", "906a695a-cf80-4320-8ca0-ee1c12270618" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "207d3c67-4914-4cc7-8e18-00d4c786adc5", "f42d0bcc-b2f7-4900-a4c1-3507976f9166" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "207d3c67-4914-4cc7-8e18-00d4c786adc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78713bd4-00af-4a34-97f7-c2953203208b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "906a695a-cf80-4320-8ca0-ee1c12270618");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f42d0bcc-b2f7-4900-a4c1-3507976f9166");
        }
    }
}
