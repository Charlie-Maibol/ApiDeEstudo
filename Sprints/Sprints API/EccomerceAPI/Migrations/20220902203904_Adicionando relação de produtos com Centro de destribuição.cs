using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace EccomerceAPI.Migrations
{
    public partial class AdicionandorelaçãodeprodutoscomCentrodedestribuição : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistributionCenter",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "distribuitonCenterId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DistribuitonCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    UF = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    Neighbourhood = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuitonCenters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_distribuitonCenterId",
                table: "Products",
                column: "distribuitonCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuitonCenters_Name",
                table: "DistribuitonCenters",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DistribuitonCenters_distribuitonCenterId",
                table: "Products",
                column: "distribuitonCenterId",
                principalTable: "DistribuitonCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DistribuitonCenters_distribuitonCenterId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "DistribuitonCenters");

            migrationBuilder.DropIndex(
                name: "IX_Products_distribuitonCenterId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "distribuitonCenterId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "DistributionCenter",
                table: "Products",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
