using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.DAL.EntityFramework.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoListId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Lists_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7503), null, new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7508), "Backlog" },
                    { 2, new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7512), null, new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7513), "InProgress" },
                    { 3, new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7514), null, new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7515), "OnHold" },
                    { 4, new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7516), null, new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7516), "Completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ToDoListId",
                table: "Items",
                column: "ToDoListId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_Label_UserId",
                table: "Lists",
                columns: new[] { "Label", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lists_UserId",
                table: "Lists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
