using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerConsole.Migrations
{
    /// <inheritdoc />
    public partial class AddStartDateEndDateToTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
