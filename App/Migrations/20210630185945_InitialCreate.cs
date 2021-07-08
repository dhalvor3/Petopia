using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name", "OwnerId" },
                values: new object[] { 1, "Lassy", null });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name", "OwnerId" },
                values: new object[] { 2, "Molly", null });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name", "OwnerId" },
                values: new object[] { 3, "Frank", null });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Don" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Jackie" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Sara" });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_OwnerId",
                table: "Dogs",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
