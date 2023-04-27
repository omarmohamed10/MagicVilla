using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeNullableToBeFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "VillaNumbers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "VillaNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2043), new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2082) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2085), new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2086) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2088), new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2089) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2091), new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2091) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2093), new DateTime(2023, 4, 19, 2, 52, 6, 708, DateTimeKind.Local).AddTicks(2095) });
        }
    }
}
