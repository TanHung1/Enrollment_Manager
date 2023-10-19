using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class checkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOuts_StatusCheckouts_StatusCheckOutId",
                table: "CheckOuts");

            migrationBuilder.DropTable(
                name: "StatusCheckouts");

            migrationBuilder.DropIndex(
                name: "IX_CheckOuts_StatusCheckOutId",
                table: "CheckOuts");

            migrationBuilder.DropColumn(
                name: "StatusCheckOutId",
                table: "CheckOuts");

            migrationBuilder.RenameColumn(
                name: "FeeType",
                table: "CheckOuts",
                newName: "StatusCheckOut");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CheckOuts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePaid",
                table: "CheckOuts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingPrice",
                table: "CheckOuts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePaid",
                table: "CheckOuts");

            migrationBuilder.DropColumn(
                name: "RemainingPrice",
                table: "CheckOuts");

            migrationBuilder.RenameColumn(
                name: "StatusCheckOut",
                table: "CheckOuts",
                newName: "FeeType");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "CheckOuts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "StatusCheckOutId",
                table: "CheckOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatusCheckouts",
                columns: table => new
                {
                    StatusCheckOutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCheckOutName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCheckouts", x => x.StatusCheckOutId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_StatusCheckOutId",
                table: "CheckOuts",
                column: "StatusCheckOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOuts_StatusCheckouts_StatusCheckOutId",
                table: "CheckOuts",
                column: "StatusCheckOutId",
                principalTable: "StatusCheckouts",
                principalColumn: "StatusCheckOutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
