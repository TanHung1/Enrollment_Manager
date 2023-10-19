using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class subjectId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Subjects_SubjectId",
                table: "ClassRooms");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "ClassRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Subjects_SubjectId",
                table: "ClassRooms",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Subjects_SubjectId",
                table: "ClassRooms");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "ClassRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Subjects_SubjectId",
                table: "ClassRooms",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId");
        }
    }
}
