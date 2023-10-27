using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStore.Shop.Infrastructure.Migrations.LogCarShop
{
    /// <inheritdoc />
    public partial class AddTableLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__LogErrors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Method = table.Column<string>(type: "character varying", unicode: false, maxLength: 100, nullable: true),
                    Path = table.Column<string>(type: "character varying", unicode: false, maxLength: 200, nullable: true),
                    Error = table.Column<string>(type: "character varying", unicode: false, maxLength: 2147483647, nullable: true),
                    ErrorFull = table.Column<string>(type: "character varying", unicode: false, maxLength: 2147483647, nullable: true),
                    Query = table.Column<string>(type: "character varying", unicode: false, maxLength: 2147483647, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_LogErrors_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "__LogRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Device = table.Column<string>(type: "character varying", unicode: false, maxLength: 600, nullable: true),
                    Host = table.Column<string>(type: "character varying", unicode: false, maxLength: 600, nullable: true),
                    Method = table.Column<string>(type: "character varying", unicode: false, maxLength: 600, nullable: true),
                    Path = table.Column<string>(type: "character varying", unicode: false, maxLength: 600, nullable: true),
                    Url = table.Column<string>(type: "character varying", unicode: false, maxLength: 600, nullable: true),
                    Header = table.Column<string>(type: "character varying", unicode: false, maxLength: 2147483647, nullable: true),
                    Body = table.Column<string>(type: "character varying", unicode: false, maxLength: 2147483647, nullable: true),
                    Query = table.Column<string>(type: "character varying", unicode: false, maxLength: 2147483647, nullable: true),
                    Ip = table.Column<string>(type: "character varying", unicode: false, maxLength: 200, nullable: true),
                    StatusCode = table.Column<int>(type: "integer", nullable: false),
                    ExecutionTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Response = table.Column<string>(type: "character varying", unicode: false, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_LogRequests_Id", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__LogErrors");

            migrationBuilder.DropTable(
                name: "__LogRequests");
        }
    }
}
