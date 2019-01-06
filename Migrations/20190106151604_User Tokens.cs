using Microsoft.EntityFrameworkCore.Migrations;

namespace mycookbook.cc.Migrations
{
    public partial class UserTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(maxLength: 20, nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Created = table.Column<string>(type: "datetime", nullable: true),
                    Expires = table.Column<string>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTokens");
        }
    }
}
