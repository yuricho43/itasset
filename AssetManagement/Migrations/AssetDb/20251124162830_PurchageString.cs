using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations.AssetDb
{
    /// <inheritdoc />
    public partial class PurchageString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RamTypel",
                table: "iTAssetMains",
                newName: "RamType");

            migrationBuilder.AlterColumn<string>(
                name: "DatePurchase",
                table: "iTAssetMains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RamType",
                table: "iTAssetMains",
                newName: "RamTypel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePurchase",
                table: "iTAssetMains",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
