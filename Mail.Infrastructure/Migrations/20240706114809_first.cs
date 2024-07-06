using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mail.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonnalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmsCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCodeValid = table.Column<bool>(type: "bit", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SenderIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagDelete = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_tbl_user_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "user_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userLog_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userLog_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userLog_tbl_user_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "user_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachedFile_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    FilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachedFile_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachedFile_tbl_File_tbl_FilesId",
                        column: x => x.FilesId,
                        principalTable: "File_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachedFile_tbl_Message_tbl_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarbonCopys_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    CarbonCopysId = table.Column<int>(type: "int", nullable: false),
                    isReaded = table.Column<bool>(type: "bit", nullable: false),
                    ReadTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarbonCopys_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarbonCopys_tbl_Message_tbl_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageLogs_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageLogs_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageLogs_tbl_Message_tbl_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receivers_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    ReceiversId = table.Column<int>(type: "int", nullable: false),
                    isReaded = table.Column<bool>(type: "bit", nullable: false),
                    ReadTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivers_tbl_Message_tbl_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachedFile_tbl_FilesId",
                table: "AttachedFile_tbl",
                column: "FilesId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachedFile_tbl_MessageId",
                table: "AttachedFile_tbl",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarbonCopys_tbl_MessageId",
                table: "CarbonCopys_tbl",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_tbl_UserId",
                table: "Message_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_tbl_MessageId",
                table: "MessageLogs_tbl",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_tbl_MessageId",
                table: "Receivers_tbl",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_userLog_tbl_UserId",
                table: "userLog_tbl",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachedFile_tbl");

            migrationBuilder.DropTable(
                name: "CarbonCopys_tbl");

            migrationBuilder.DropTable(
                name: "MessageLogs_tbl");

            migrationBuilder.DropTable(
                name: "Receivers_tbl");

            migrationBuilder.DropTable(
                name: "userLog_tbl");

            migrationBuilder.DropTable(
                name: "File_tbl");

            migrationBuilder.DropTable(
                name: "Message_tbl");

            migrationBuilder.DropTable(
                name: "user_tbl");
        }
    }
}
