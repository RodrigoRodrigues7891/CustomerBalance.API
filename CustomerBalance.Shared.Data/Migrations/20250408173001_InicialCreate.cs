using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerBalance.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerLedgers",
                columns: table => new
                {
                    AN8 = table.Column<int>(type: "int", nullable: false),
                    DCT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOC = table.Column<int>(type: "int", nullable: false),
                    DTR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DVJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AG = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    AAP = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    AAR = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLedgers", x => new { x.AN8, x.DCT, x.DOC });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerLedgers");
        }
    }
}
