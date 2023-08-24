using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagerConsole.Migrations
{
    public partial class EntityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks"); // Drop the original "Tasks" table

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Add the IDENTITY annotation
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks"); // Drop the "Tasks" table
        }
    }
}