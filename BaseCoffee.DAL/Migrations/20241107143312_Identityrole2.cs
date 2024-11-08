using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseCoffee.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Identityrole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "252d1809-cd07-4ebd-87d1-83cefac3b78c",
                columns: new[] { "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEIHlfUCvWFLDmBxRnS7J6dzUWpZ7YiMOMwPRkC9IqtLbXNVBWj/UOHSZm5+CKp3GZQ==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 11, 5, 17, 33, 11, 395, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 11, 6, 17, 33, 11, 395, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 11, 7, 17, 33, 11, 395, DateTimeKind.Local).AddTicks(5004));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "252d1809-cd07-4ebd-87d1-83cefac3b78c",
                columns: new[] { "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ADMIN@GMAİL.COM", "AQAAAAIAAYagAAAAEKG5m+hxbz10+k15f6HcD7hITu/Ym/jryX+7S9jwam1hwzgTkAFgMtRXzq9Jfzr2Dg==" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 11, 5, 17, 27, 19, 467, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 11, 6, 17, 27, 19, 467, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 11, 7, 17, 27, 19, 467, DateTimeKind.Local).AddTicks(9409));
        }
    }
}
