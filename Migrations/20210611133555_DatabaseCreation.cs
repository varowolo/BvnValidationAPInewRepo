using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BvnValidationAPInew.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblRequestAndResponseLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    RequestType = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    RequestPayload = table.Column<string>(maxLength: 5000, nullable: false),
                    RequestId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Response = table.Column<string>(maxLength: 2147483647, nullable: true),
                    RequestTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    ResponseTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    RequestBaseUrl = table.Column<string>(maxLength: 2147483647, nullable: false),
                    RequestEndpoint = table.Column<string>(maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestAndResponseLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRequestAndResponseLog");
        }
    }
}
