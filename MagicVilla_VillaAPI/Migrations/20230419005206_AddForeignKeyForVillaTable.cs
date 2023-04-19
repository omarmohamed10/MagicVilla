using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyForVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumbers");

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
    }
}
