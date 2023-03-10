using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAPI.Migrations
{
    public partial class criandolojista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "708abe49-aa7c-4e96-b51f-08e7fd662757");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "dee5c53f-f15b-45ff-8e61-1a20b7364f06");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "841e6eb5-c2a8-494e-92a8-d34742cc2546", "lojista", "LOJISTA" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "BirthDay", "ConcurrencyStamp", "CriatonDate", "Modified", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2023, 3, 10, 9, 4, 23, 319, DateTimeKind.Local).AddTicks(4590), "291053b0-20ef-49d8-bfe5-cbd7d8bba244", new DateTime(2023, 3, 10, 9, 4, 23, 319, DateTimeKind.Local).AddTicks(4268), new DateTime(2023, 3, 10, 9, 4, 23, 319, DateTimeKind.Local).AddTicks(1435), "AQAAAAEAACcQAAAAEN61NopIvvCzxb3ELWRqQAUIT4ykL4WISZ8mRRn2Hx61kpH9XTBjxHy8bibiDLDmQw==", "ffd522a3-c7c3-4e47-ad48-50e0c5d7e705" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "959f4555-a963-4fe2-adc1-d9852fcb6644");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "025c27b6-2ac3-47f0-a3e9-90780a765e36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "BirthDay", "ConcurrencyStamp", "CriatonDate", "Modified", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 12, 22, 9, 18, 41, 717, DateTimeKind.Local).AddTicks(902), "1f5313bf-1745-4b22-a52f-7516bf16e8fa", new DateTime(2022, 12, 22, 9, 18, 41, 717, DateTimeKind.Local).AddTicks(629), new DateTime(2022, 12, 22, 9, 18, 41, 716, DateTimeKind.Local).AddTicks(7877), "AQAAAAEAACcQAAAAEBqN9J+NJUTlmb7xV2gs6LWurgyWlnevC5XQrI2SmpQXqg4m0jIF6By0eb5t38SobA==", "0de83682-a4d3-41d0-86bb-96be97bb8073" });
        }
    }
}
