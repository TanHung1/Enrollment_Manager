using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phanmemquanlyghidanh.Migrations
{
    /// <inheritdoc />
    public partial class classroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "CheckOuts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassRoomId",
                table: "Schedules",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_ClassRoomId",
                table: "Marks",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_ClassRoomId",
                table: "CheckOuts",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClassRoomId",
                table: "Accounts",
                column: "ClassRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_ClassRooms_ClassRoomId",
                table: "Accounts",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOuts_ClassRooms_ClassRoomId",
                table: "CheckOuts",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_ClassRooms_ClassRoomId",
                table: "Marks",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_ClassRooms_ClassRoomId",
                table: "Schedules",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_ClassRooms_ClassRoomId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckOuts_ClassRooms_ClassRoomId",
                table: "CheckOuts");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_ClassRooms_ClassRoomId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_ClassRooms_ClassRoomId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ClassRoomId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Marks_ClassRoomId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_CheckOuts_ClassRoomId",
                table: "CheckOuts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ClassRoomId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "CheckOuts");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Accounts");
        }
    }
}
