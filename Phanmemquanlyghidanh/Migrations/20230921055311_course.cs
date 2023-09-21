using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Course_Id",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Course_Id",
                table: "Subjects",
                column: "Course_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Courses_Course_Id",
                table: "Subjects",
                column: "Course_Id",
                principalTable: "Courses",
                principalColumn: "Course_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Courses_Course_Id",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Course_Id",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Course_Id",
                table: "Subjects");
        }
    }
}
