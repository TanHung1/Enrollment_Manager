using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class addtypemark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeMarkTypeID",
                table: "Marks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeMarks",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMarks", x => x.TypeID);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_TypeMarks_TypeMarkTypeID",
                table: "Marks");

            migrationBuilder.DropTable(
                name: "TypeMarks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_TypeMarkTypeID",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "TypeMarkTypeID",
                table: "Marks");
        }
    }
}
