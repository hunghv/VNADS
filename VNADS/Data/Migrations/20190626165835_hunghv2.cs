using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class hunghv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VNADS_AdsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_AdsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_ApplicationLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Icon = table.Column<string>(maxLength: 128, nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_ApplicationLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_PostType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_PostType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    ConfirmPassword = table.Column<string>(maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    ThumbnailPhoto = table.Column<byte[]>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ReceiveEmail = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    TelephoneNumber = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_AdsForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    AdsTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_AdsForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VNADS_AdsForm_VNADS_AdsType_AdsTypeId",
                        column: x => x.AdsTypeId,
                        principalTable: "VNADS_AdsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_UserLoginHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    AccessToken = table.Column<Guid>(nullable: false),
                    IsLoggedOut = table.Column<bool>(nullable: false),
                    IsAppToken = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_UserLoginHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VNADS_UserLoginHistory_VNADS_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "VNADS_UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    UserProfileId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VNADS_UserRole_VNADS_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "VNADS_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VNADS_UserRole_VNADS_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "VNADS_UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    PostTypeId = table.Column<int>(nullable: false),
                    UserProfileId = table.Column<int>(nullable: false),
                    AdsFormId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Price = table.Column<float>(nullable: false),
                    PriceDescription = table.Column<string>(maxLength: 50, nullable: true),
                    Property1 = table.Column<string>(maxLength: 50, nullable: true),
                    Property2 = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VNADS_Post_VNADS_AdsForm_AdsFormId",
                        column: x => x.AdsFormId,
                        principalTable: "VNADS_AdsForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VNADS_Post_VNADS_PostType_PostTypeId",
                        column: x => x.PostTypeId,
                        principalTable: "VNADS_PostType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VNADS_Post_VNADS_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "VNADS_UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VNADS_PostImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNADS_PostImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VNADS_PostImage_VNADS_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "VNADS_Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VNADS_PostImage_VNADS_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "VNADS_Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VNADS_ApplicationLanguage",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DisplayName", "Icon", "IsDeleted", "IsDisabled", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(664), null, null, "English", "famfamfam-flags gb", false, false, null, null, "en" },
                    { 2, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(681), null, null, "العربية", "famfamfam-flags sa", false, false, null, null, "ar" },
                    { 3, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(683), null, null, "German", "famfamfam-flags de", false, false, null, null, "de" },
                    { 4, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(684), null, null, "Italiano", "famfamfam-flags it", false, false, null, null, "it" },
                    { 5, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(685), null, null, "Français", "famfamfam-flags fr", false, false, null, null, "fr" },
                    { 6, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(691), null, null, "Português", "famfamfam-flags br", false, false, null, null, "pt-BR" },
                    { 7, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(692), null, null, "Türkçe", "famfamfam-flags tr", false, false, null, null, "tr" },
                    { 8, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(693), null, null, "Русский", "famfamfam-flags ru", false, false, null, null, "ru" },
                    { 9, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(694), null, null, "简体中文", "famfamfam-flags cn", false, false, null, null, "zh-Hans" },
                    { 10, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(697), null, null, "Español México", "famfamfam-flags mx", false, false, null, null, "es-MX" },
                    { 11, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(698), null, null, "Nederlands", "famfamfam-flags nl", false, false, null, null, "nl" },
                    { 12, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(699), null, null, "日本語", "famfamfam-flags jp", false, false, null, null, "ja" },
                    { 13, 1, new DateTime(2019, 6, 26, 23, 58, 35, 364, DateTimeKind.Local).AddTicks(700), null, null, "Viet Nam", "famfamfam-flags vn", false, false, null, null, "vn" }
                });

            migrationBuilder.InsertData(
                table: "VNADS_Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 6, 26, 23, 58, 35, 361, DateTimeKind.Local).AddTicks(8929), null, null, false, null, null, "Administrator" },
                    { 2, 1, new DateTime(2019, 6, 26, 23, 58, 35, 362, DateTimeKind.Local).AddTicks(6677), null, null, false, null, null, "Poster" },
                    { 3, 1, new DateTime(2019, 6, 26, 23, 58, 35, 362, DateTimeKind.Local).AddTicks(6687), null, null, false, null, null, "Normal User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_AdsForm_AdsTypeId",
                table: "VNADS_AdsForm",
                column: "AdsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_Post_AdsFormId",
                table: "VNADS_Post",
                column: "AdsFormId");

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_Post_PostTypeId",
                table: "VNADS_Post",
                column: "PostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_Post_UserProfileId",
                table: "VNADS_Post",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_PostImage_ImageId",
                table: "VNADS_PostImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_PostImage_PostId",
                table: "VNADS_PostImage",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_UserLoginHistory_UserId",
                table: "VNADS_UserLoginHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_UserRole_RoleId",
                table: "VNADS_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VNADS_UserRole_UserProfileId",
                table: "VNADS_UserRole",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VNADS_ApplicationLanguage");

            migrationBuilder.DropTable(
                name: "VNADS_PostImage");

            migrationBuilder.DropTable(
                name: "VNADS_UserLoginHistory");

            migrationBuilder.DropTable(
                name: "VNADS_UserRole");

            migrationBuilder.DropTable(
                name: "VNADS_Image");

            migrationBuilder.DropTable(
                name: "VNADS_Post");

            migrationBuilder.DropTable(
                name: "VNADS_Roles");

            migrationBuilder.DropTable(
                name: "VNADS_AdsForm");

            migrationBuilder.DropTable(
                name: "VNADS_PostType");

            migrationBuilder.DropTable(
                name: "VNADS_UserProfile");

            migrationBuilder.DropTable(
                name: "VNADS_AdsType");
        }
    }
}
