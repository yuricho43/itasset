using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations.AssetDb
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "changeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeColumns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeDescripton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_changeHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "columnsInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Selector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_columnsInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "iTAssetMains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonitorNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonitorInch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonitorNum = table.Column<int>(type: "int", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceMaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpuType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamTypel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VgaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WMacAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OsType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePurchase = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MacAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iTAssetMains", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "changeHistories");

            migrationBuilder.DropTable(
                name: "columnsInfos");

            migrationBuilder.DropTable(
                name: "iTAssetMains");
        }
    }
}
