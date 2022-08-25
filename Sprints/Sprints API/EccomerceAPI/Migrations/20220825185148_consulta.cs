﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EccomerceAPI.Migrations
{
    public partial class consulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Consult",
                table: "Products",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consult",
                table: "Products");
        }
    }
}
