using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalUserstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9337), new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9382), new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9383) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9385), new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9388), new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9391), new DateTime(2023, 6, 21, 1, 52, 10, 997, DateTimeKind.Local).AddTicks(9391) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5197), new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5209), new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5209) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5211), new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5211) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5213), new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5213) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5215), new DateTime(2023, 4, 26, 20, 12, 48, 534, DateTimeKind.Local).AddTicks(5215) });
        }
    }
}
