using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.DAL.EntityFramework.Migrations
{
    public partial class ExampleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9050), new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9063), new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9064) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9065), new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9067), new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9067) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "ExternalId", "LastUpdated", "UserName" },
                values: new object[] { 1, new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9473), null, "OAuthProviderExample_1", new DateTime(2022, 9, 11, 8, 33, 30, 639, DateTimeKind.Utc).AddTicks(9473), "Stephen Rodgers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7503), new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7512), new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7514), new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7515) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7516), new DateTime(2022, 9, 10, 21, 50, 31, 781, DateTimeKind.Utc).AddTicks(7516) });
        }
    }
}
