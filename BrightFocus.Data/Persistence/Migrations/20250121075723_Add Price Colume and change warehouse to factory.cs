using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightFocus.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceColumeandchangewarehousetofactory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialWarehouses");

            migrationBuilder.DropColumn(
                name: "Warehouse",
                table: "TaskImport");

            migrationBuilder.DropColumn(
                name: "Warehouse",
                table: "TaskDetails");

            migrationBuilder.DropColumn(
                name: "Warehouse",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Warehouse",
                table: "TaskExport",
                newName: "Factory");

            migrationBuilder.RenameColumn(
                name: "Warehouse",
                table: "ProductMaterials",
                newName: "Factory");

            migrationBuilder.RenameColumn(
                name: "Warehouse",
                table: "OrderExport",
                newName: "Factory");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TaskImport",
                type: "double",
                nullable: false,
                defaultValue: 0.0)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TaskDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Order",
                type: "double",
                nullable: false,
                defaultValue: 0.0)
                .Annotation("Relational:ColumnOrder", 9);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TaskImport");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TaskDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Factory",
                table: "TaskExport",
                newName: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "Factory",
                table: "ProductMaterials",
                newName: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "Factory",
                table: "OrderExport",
                newName: "Warehouse");

            migrationBuilder.AddColumn<string>(
                name: "Warehouse",
                table: "TaskImport",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "Warehouse",
                table: "TaskDetails",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "Warehouse",
                table: "Order",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.CreateTable(
                name: "MaterialWarehouses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductCode = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Material = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantification = table.Column<double>(type: "double", nullable: false),
                    Color = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Characteristic = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<double>(type: "double", nullable: false),
                    Volume = table.Column<double>(type: "double", nullable: false),
                    Warehouse = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReceiptNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaterialProductType = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    CreatedDateTS = table.Column<double>(type: "double", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "double", nullable: true),
                    DeletedDateTS = table.Column<double>(type: "double", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialWarehouses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialWarehouses_ProductName_Characteristic_FileNumber",
                table: "MaterialWarehouses",
                columns: new[] { "ProductName", "Characteristic", "FileNumber" });
        }
    }
}
