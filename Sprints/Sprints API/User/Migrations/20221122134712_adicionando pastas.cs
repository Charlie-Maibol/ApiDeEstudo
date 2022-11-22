using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAPI.Migrations
{
    public partial class adicionandopastas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "AspNetUsers",
                type: "varchar(767)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "b52c0ef8-4d3a-4580-8f32-5a6700651e8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "118cf304-93b6-4ef2-aec7-73696f85e9db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "BirthDay", "ConcurrencyStamp", "CriatonDate", "Modified", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 11, 22, 10, 47, 11, 359, DateTimeKind.Local).AddTicks(2627), "46d7e6b6-b5b6-4c47-8507-41f9c795bd56", new DateTime(2022, 11, 22, 10, 47, 11, 359, DateTimeKind.Local).AddTicks(2236), new DateTime(2022, 11, 22, 10, 47, 11, 358, DateTimeKind.Local).AddTicks(7627), "AQAAAAEAACcQAAAAEHMyywdJY2QD4Ytz0Kj8PsvuLjCzQo/ZlUfG2OSKoIvFdhOqdQt41b8rRyUmdyfksQ==", "fde809a4-e0e9-493c-b97c-4ea0fbe26b9d" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CPF",
                table: "AspNetUsers",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CPF",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(767)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "0560c09e-889c-486e-90f2-52cc5fd04e7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "02f88b33-cf2a-4fbd-ac17-5e610e739e66");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "BirthDay", "ConcurrencyStamp", "CriatonDate", "Modified", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 11, 22, 10, 44, 16, 684, DateTimeKind.Local).AddTicks(243), "6f14b349-ca71-4663-a7b4-ec28d7a75eb0", new DateTime(2022, 11, 22, 10, 44, 16, 683, DateTimeKind.Local).AddTicks(9786), new DateTime(2022, 11, 22, 10, 44, 16, 683, DateTimeKind.Local).AddTicks(933), "AQAAAAEAACcQAAAAEGChef0NwJApumEd/eiO/JDGnFmBzg2m3byTgs7SIk706JumSFEahlNtweTO4swBSw==", "663f3d2c-598a-4eef-abf5-ce9f2c286aa3" });
        }
    }
}
