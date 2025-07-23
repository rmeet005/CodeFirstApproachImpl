using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JunBatchCodeFirstApproachImpl.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mid",
                table: "employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Mid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Mid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_Mid",
                table: "employee",
                column: "Mid");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_Manager_Mid",
                table: "employee",
                column: "Mid",
                principalTable: "Manager",
                principalColumn: "Mid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_Manager_Mid",
                table: "employee");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_employee_Mid",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "Mid",
                table: "employee");
        }
    }
}
