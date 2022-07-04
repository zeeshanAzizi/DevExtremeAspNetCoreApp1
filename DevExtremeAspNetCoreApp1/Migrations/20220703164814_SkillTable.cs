using Microsoft.EntityFrameworkCore.Migrations;

namespace DevExtremeAspNetCoreApp1.Migrations
{
    public partial class SkillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillID",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SkillID",
                table: "Students",
                column: "SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Skills_SkillID",
                table: "Students",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Skills_SkillID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Students_SkillID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SkillID",
                table: "Students");
        }
    }
}
