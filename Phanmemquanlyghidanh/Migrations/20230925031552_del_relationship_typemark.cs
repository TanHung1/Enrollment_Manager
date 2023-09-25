using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class del_relationship_typemark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_TypeMarks_TypeMarkTypeID",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_TypeMarkTypeID",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "TypeMarkTypeID",
                table: "Marks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeMarkTypeID",
                table: "Marks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_TypeMarkTypeID",
                table: "Marks",
                column: "TypeMarkTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_TypeMarks_TypeMarkTypeID",
                table: "Marks",
                column: "TypeMarkTypeID",
                principalTable: "TypeMarks",
                principalColumn: "TypeID");
        }
    }
}
