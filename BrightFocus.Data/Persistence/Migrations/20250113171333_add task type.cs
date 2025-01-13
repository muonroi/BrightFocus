using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightFocus.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtasktype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TaskId",
                table: "Dashboard",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModificationUserId",
                table: "Dashboard",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 28)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 27);

            migrationBuilder.AlterColumn<double>(
                name: "LastModificationTimeTs",
                table: "Dashboard",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 22)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Dashboard",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 27)
                .OldAnnotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Dashboard",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("Relational:ColumnOrder", 24)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionTime",
                table: "Dashboard",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 29)
                .OldAnnotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedUserId",
                table: "Dashboard",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<double>(
                name: "DeletedDateTS",
                table: "Dashboard",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 23)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "Dashboard",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("Relational:ColumnOrder", 26)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Dashboard",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("Relational:ColumnOrder", 25)
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<double>(
                name: "CreatedDateTS",
                table: "Dashboard",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double")
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AddColumn<int>(
                name: "TaskType",
                table: "Dashboard",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ingredient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Characteristic = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ColorCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Volume = table.Column<double>(type: "double", nullable: false),
                    Warehouse = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Structure = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TaskId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                    table.PrimaryKey("PK_Order", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TaskId",
                table: "Order",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropColumn(
                name: "TaskType",
                table: "Dashboard");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskId",
                table: "Dashboard",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModificationUserId",
                table: "Dashboard",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 27)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<double>(
                name: "LastModificationTimeTs",
                table: "Dashboard",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Dashboard",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 26)
                .OldAnnotation("Relational:ColumnOrder", 27);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Dashboard",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("Relational:ColumnOrder", 23)
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionTime",
                table: "Dashboard",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 28)
                .OldAnnotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedUserId",
                table: "Dashboard",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 29)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<double>(
                name: "DeletedDateTS",
                table: "Dashboard",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 22)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "Dashboard",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("Relational:ColumnOrder", 25)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Dashboard",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("Relational:ColumnOrder", 24)
                .OldAnnotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<double>(
                name: "CreatedDateTS",
                table: "Dashboard",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double")
                .Annotation("Relational:ColumnOrder", 20)
                .OldAnnotation("Relational:ColumnOrder", 21);
        }
    }
}
