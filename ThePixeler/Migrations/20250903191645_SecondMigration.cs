using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThePixeler.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "zPosition",
                table: "Pixels",
                newName: "yPosition");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "B",
                table: "Pixels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "G",
                table: "Pixels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "R",
                table: "Pixels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserID",
                table: "Rooms",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserID",
                table: "Rooms",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "B",
                table: "Pixels");

            migrationBuilder.DropColumn(
                name: "G",
                table: "Pixels");

            migrationBuilder.DropColumn(
                name: "R",
                table: "Pixels");

            migrationBuilder.RenameColumn(
                name: "yPosition",
                table: "Pixels",
                newName: "zPosition");
        }
    }
}
