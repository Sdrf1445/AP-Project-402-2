using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Manager.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentRestaurantID",
                table: "Restaurants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentRestaurantID",
                table: "Restaurants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
