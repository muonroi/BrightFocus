#nullable disable

namespace BrightFocus.Data.Persistence.Migrations;

/// <inheritdoc />
public partial class InitDb : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MLanguages",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                DisplayName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Icon = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsDisabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                table.PrimaryKey("PK_MLanguages", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MPermissions",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsGranted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                Discriminator = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
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
                table.PrimaryKey("PK_MPermissions", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MRefreshTokens",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Token = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TokenValidityKey = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ExpiredDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                RevokedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                ReasonRevoked = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsRevoked = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                table.PrimaryKey("PK_MRefreshTokens", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MRolePermissions",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                PermissionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                table.PrimaryKey("PK_MRolePermissions", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MRoles",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                DisplayName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                NormalizedName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsStatic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                ConcurrencyStamp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
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
                table.PrimaryKey("PK_MRoles", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MUserLoginAttempts",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                UserGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                UserNameOrEmailAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClientIpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClientName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                BrowserInfo = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Result = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                AttemptTime = table.Column<int>(type: "int", nullable: false),
                LockTo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                table.PrimaryKey("PK_MUserLoginAttempts", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MUserRoles",
            columns: table => new
            {
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                table.PrimaryKey("PK_MUserRoles", x => new { x.UserId, x.RoleId });
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MUsers",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                EmailAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Surname = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Password = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PasswordResetCode = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PhoneNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsPhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                SecurityStamp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsTwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                IsEmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                NormalizedEmailAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ConcurrencyStamp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Salt = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ProfilePictureId = table.Column<int>(type: "int", nullable: true),
                ShouldChangePasswordOnNextLogin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                SignInTokenExpireTimeUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                table.PrimaryKey("PK_MUsers", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "MUserTokens",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                UserId = table.Column<long>(type: "bigint", nullable: false),
                LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Value = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ExpireDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                table.PrimaryKey("PK_MUserTokens", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "TaskDetail",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Material = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Size = table.Column<double>(type: "double", maxLength: 255, nullable: false),
                FabricMeter = table.Column<double>(type: "double", maxLength: 255, nullable: false),
                Weight = table.Column<double>(type: "double", maxLength: 255, nullable: false),
                Color = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Employee = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Warehouse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                DeadlineDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                TaskType = table.Column<int>(type: "int", nullable: false),
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
                table.PrimaryKey("PK_TaskDetail", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "TaskList",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Material = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Size = table.Column<double>(type: "double", nullable: false),
                Weight = table.Column<double>(type: "double", nullable: false),
                Color = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Employee = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                FactoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Warehouse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                DeadlineDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                FileUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TaskType = table.Column<int>(type: "int", nullable: false),
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
                table.PrimaryKey("PK_TaskList", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Warehouse",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                EntityId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Description = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                FactoryName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Address = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
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
                table.PrimaryKey("PK_Warehouse", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_MLanguages_Name",
            table: "MLanguages",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_MPermissions_Name",
            table: "MPermissions",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_MRoles_Name",
            table: "MRoles",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_MUserLoginAttempt_UserNameOrEmailAddress",
            table: "MUserLoginAttempts",
            column: "UserNameOrEmailAddress");

        migrationBuilder.CreateIndex(
            name: "IX_MUser_UserName",
            table: "MUsers",
            column: "UserName",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_MUserToken_LoginProvider",
            table: "MUserTokens",
            column: "LoginProvider");

        migrationBuilder.CreateIndex(
            name: "IX_TaskDetail_ProductName",
            table: "TaskDetail",
            column: "ProductName");

        migrationBuilder.CreateIndex(
            name: "IX_TaskList_ProductName",
            table: "TaskList",
            column: "ProductName");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MLanguages");

        migrationBuilder.DropTable(
            name: "MPermissions");

        migrationBuilder.DropTable(
            name: "MRefreshTokens");

        migrationBuilder.DropTable(
            name: "MRolePermissions");

        migrationBuilder.DropTable(
            name: "MRoles");

        migrationBuilder.DropTable(
            name: "MUserLoginAttempts");

        migrationBuilder.DropTable(
            name: "MUserRoles");

        migrationBuilder.DropTable(
            name: "MUsers");

        migrationBuilder.DropTable(
            name: "MUserTokens");

        migrationBuilder.DropTable(
            name: "TaskDetail");

        migrationBuilder.DropTable(
            name: "TaskList");

        migrationBuilder.DropTable(
            name: "Warehouse");
    }
}
