using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerBalance.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerLedgers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "CustomerLedgers",
            columns: new[] { "AN8", "DCT", "DOC", "DTR", "DVJ", "AID", "AG", "AAR", "AAP" },
            values: new object[,]
            {
                { 1001, "RI", 123456, "2024-12-01", "2025-01-01", "O", 1200.00m, 1200.00m, 0.00m },
                { 1001, "RI", 123457, "2025-01-10", "2025-02-10", "O", 800.00m, 800.00m, 0.00m },
                { 1001, "RI", 123458, "2024-10-05", "2024-11-05", "P", 500.00m, 0.00m, 500.00m },
                { 1002, "RM", 223456, "2024-11-01", "2024-12-01", "O", 750.00m, 750.00m, 0.00m },
                { 1002, "RM", 223457, "2024-12-05", "2025-01-05", "1", 200.00m, 200.00m, 0.00m },
                { 1002, "RM", 223458, "2025-01-15", "2025-02-15", "O", 300.00m, 300.00m, 0.00m },
                { 1003, "RI", 323456, "2024-09-01", "2024-10-01", "P", 1000.00m, 0.00m, 1000.00m },
                { 1003, "RI", 323457, "2024-09-15", "2024-10-15", "P", 150.00m, 0.00m, 150.00m },
                { 1004, "RI", 423456, "2025-02-01", "2025-03-01", "O", 2300.00m, 2300.00m, 0.00m },
                { 1004, "RI", 423457, "2025-02-15", "2025-03-15", "O", 100.00m, 100.00m, 0.00m },
                { 1004, "RI", 423458, "2024-10-10", "2024-11-10", "P", 900.00m, 0.00m, 900.00m },
                { 1005, "RI", 523456, "2025-01-20", "2025-02-20", "O", 450.00m, 450.00m, 0.00m },
                { 1005, "RI", 523457, "2025-02-10", "2025-03-10", "2", 100.00m, 100.00m, 0.00m }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "CustomerLedgers",
            keyColumns: new[] { "AN8", "DCT", "DOC" },
            keyValues: new object[,]
            {
                { 1001, "RI", 123456 },
                { 1001, "RI", 123457 },
                { 1001, "RI", 123458 },
                { 1002, "RM", 223456 },
                { 1002, "RM", 223457 },
                { 1002, "RM", 223458 },
                { 1003, "RI", 323456 },
                { 1003, "RI", 323457 },
                { 1004, "RI", 423456 },
                { 1004, "RI", 423457 },
                { 1004, "RI", 423458 },
                { 1005, "RI", 523456 },
                { 1005, "RI", 523457 }
            });
        }
    }
}
