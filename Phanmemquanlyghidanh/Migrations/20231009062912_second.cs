using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountMark");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Marks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_AccountId",
                table: "Marks",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Accounts_AccountId",
                table: "Marks",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Accounts_AccountId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_AccountId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Marks");

            migrationBuilder.CreateTable(
                name: "AccountMark",
                columns: table => new
                {
                    AccountsId = table.Column<int>(type: "int", nullable: false),
                    marksMarkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountMark", x => new { x.AccountsId, x.marksMarkId });
                    table.ForeignKey(
                        name: "FK_AccountMark_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountMark_Marks_marksMarkId",
                        column: x => x.marksMarkId,
                        principalTable: "Marks",
                        principalColumn: "MarkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountMark_marksMarkId",
                table: "AccountMark",
                column: "marksMarkId");
        }
    }
}
