using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightFocus.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnProcessStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductEight",
                table: "ProductProcess");

            migrationBuilder.DropColumn(
                name: "ProductFive",
                table: "ProductProcess");

            migrationBuilder.DropColumn(
                name: "ProductFour",
                table: "ProductProcess");

            migrationBuilder.DropColumn(
                name: "ProductOne",
                table: "ProductProcess");

            migrationBuilder.DropColumn(
                name: "ProductSeven",
                table: "ProductProcess");

            migrationBuilder.DropColumn(
                name: "ProductSix",
                table: "ProductProcess");

            migrationBuilder.DropColumn(
                name: "ProductThree",
                table: "ProductProcess");

            migrationBuilder.RenameColumn(
                name: "ProductTwo",
                table: "ProductProcess",
                newName: "ProcessName");

            migrationBuilder.AlterColumn<int>(
                name: "WrapperId",
                table: "ProductProcess",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskId",
                table: "ProductProcess",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModificationUserId",
                table: "ProductProcess",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 24)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<double>(
                name: "LastModificationTimeTs",
                table: "ProductProcess",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 18)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductProcess",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 23)
                .OldAnnotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProductProcess",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("Relational:ColumnOrder", 20)
                .OldAnnotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionTime",
                table: "ProductProcess",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 25)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedUserId",
                table: "ProductProcess",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 26)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 31);

            migrationBuilder.AlterColumn<double>(
                name: "DeletedDateTS",
                table: "ProductProcess",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 19)
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "ProductProcess",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("Relational:ColumnOrder", 22)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 27);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "ProductProcess",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<double>(
                name: "CreatedDateTS",
                table: "ProductProcess",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double")
                .Annotation("Relational:ColumnOrder", 17)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<string>(
                name: "ProcessCategory",
                table: "ProductProcess",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<string>(
                name: "ProcessCode",
                table: "ProductProcess",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessCategory",
                table: "ProductProcess");

            migrationBuilder.DropColumn(
                name: "ProcessCode",
                table: "ProductProcess");

            migrationBuilder.RenameColumn(
                name: "ProcessName",
                table: "ProductProcess",
                newName: "ProductTwo");

            migrationBuilder.AlterColumn<int>(
                name: "WrapperId",
                table: "ProductProcess",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskId",
                table: "ProductProcess",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModificationUserId",
                table: "ProductProcess",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 29)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<double>(
                name: "LastModificationTimeTs",
                table: "ProductProcess",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 23)
                .OldAnnotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductProcess",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 28)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProductProcess",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("Relational:ColumnOrder", 25)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionTime",
                table: "ProductProcess",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedUserId",
                table: "ProductProcess",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<double>(
                name: "DeletedDateTS",
                table: "ProductProcess",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 24)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "ProductProcess",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("Relational:ColumnOrder", 27)
                .OldAnnotation("Relational:Collation", "ascii_general_ci")
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "ProductProcess",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("Relational:ColumnOrder", 26)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<double>(
                name: "CreatedDateTS",
                table: "ProductProcess",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double")
                .Annotation("Relational:ColumnOrder", 22)
                .OldAnnotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<string>(
                name: "ProductEight",
                table: "ProductProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "ProductFive",
                table: "ProductProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "ProductFour",
                table: "ProductProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<string>(
                name: "ProductOne",
                table: "ProductProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "ProductSeven",
                table: "ProductProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "ProductSix",
                table: "ProductProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<string>(
                name: "ProductThree",
                table: "ProductProcess",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 4);
        }
    }
}
