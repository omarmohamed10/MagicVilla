using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7637), new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7677) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7684), new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7686) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7688), new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7690), new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7693), new DateTime(2023, 4, 18, 12, 0, 45, 586, DateTimeKind.Local).AddTicks(7694) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9665), new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9673) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9675), new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9677), new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9677) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9679), new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9680), new DateTime(2023, 3, 27, 14, 44, 1, 659, DateTimeKind.Local).AddTicks(9681) });
        }
    }
}
