using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Manager.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_users_Username",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_restaurants",
                table: "restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_menus",
                table: "menus");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "restaurants",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "menus",
                newName: "Menus");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Restaurants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_Username",
                table: "Order",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_Username",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "restaurants");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "menus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_restaurants",
                table: "restaurants",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_menus",
                table: "menus",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_users_Username",
                table: "Order",
                column: "Username",
                principalTable: "users",
                principalColumn: "Username");
        }
    }
}
