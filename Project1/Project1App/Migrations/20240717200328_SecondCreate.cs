using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Logins_Players_LoginID",
                        column: x => x.LoginID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
