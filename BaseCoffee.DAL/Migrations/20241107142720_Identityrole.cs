using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseCoffee.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Identityrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "329d3be5-8001-4997-85a9-ebc16be771c2", null, "Admin", "ADMIN" },
                    { "c9bbce7e-7372-47f2-80e9-029ce117f245", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "252d1809-cd07-4ebd-87d1-83cefac3b78c", 0, "55c5fc1a-1d71-4de4-b65e-e14eed798ade", "admin@gmail.com", true, false, null, null, "ADMIN@GMAİL.COM", "AQAAAAIAAYagAAAAEKG5m+hxbz10+k15f6HcD7hITu/Ym/jryX+7S9jwam1hwzgTkAFgMtRXzq9Jfzr2Dg==", null, false, "87b82a5e-69c1-4831-87d0-678b208084ae", false, "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppUserID", "OrderDate" },
                values: new object[] { null, new DateTime(2024, 11, 5, 17, 27, 19, 467, DateTimeKind.Local).AddTicks(9399) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppUserID", "OrderDate" },
                values: new object[] { null, new DateTime(2024, 11, 6, 17, 27, 19, 467, DateTimeKind.Local).AddTicks(9407) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppUserID", "OrderDate" },
                values: new object[] { null, new DateTime(2024, 11, 7, 17, 27, 19, 467, DateTimeKind.Local).AddTicks(9409) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "329d3be5-8001-4997-85a9-ebc16be771c2", "252d1809-cd07-4ebd-87d1-83cefac3b78c" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserID",
                table: "Orders",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserID",
                table: "Orders",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AppUserID",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9bbce7e-7372-47f2-80e9-029ce117f245");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "329d3be5-8001-4997-85a9-ebc16be771c2", "252d1809-cd07-4ebd-87d1-83cefac3b78c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "329d3be5-8001-4997-85a9-ebc16be771c2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "252d1809-cd07-4ebd-87d1-83cefac3b78c");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 11, 5, 16, 53, 0, 880, DateTimeKind.Local).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 11, 6, 16, 53, 0, 880, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 11, 7, 16, 53, 0, 880, DateTimeKind.Local).AddTicks(848));
        }
    }
}
