using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLDotNetCore.Migrations
{
    public partial class InitialDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("2c22c84d-563b-49a4-b36d-1b40c47735d8"), "John Doe's address", "John Doe" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("482d51db-5e3f-46b9-bd9f-7303bcb4b4b9"), "Jane Doe's address", "Jane Doe" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[] { new Guid("baab1c53-0c94-42c7-898e-9ca324bd8ca3"), "Cash account for our users", new Guid("2c22c84d-563b-49a4-b36d-1b40c47735d8"), 0 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[] { new Guid("ad5ea9b0-00ed-442d-b6cc-cc54020cb93c"), "Savings account for our users", new Guid("482d51db-5e3f-46b9-bd9f-7303bcb4b4b9"), 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[] { new Guid("9769d8ae-8177-4ebd-becd-d1ce1e2fbcb6"), "Income account for our users", new Guid("482d51db-5e3f-46b9-bd9f-7303bcb4b4b9"), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
