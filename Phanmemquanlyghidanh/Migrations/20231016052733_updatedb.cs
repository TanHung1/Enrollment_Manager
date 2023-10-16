using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
