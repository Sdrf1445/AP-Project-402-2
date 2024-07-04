using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_Manager.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Comment_ReplyID",
                table: "Complaints");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "restaurants");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "menus");

            migrationBuilder.RenameTable(
                name: "Complaints",
                newName: "complaints");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_ReplyID",
                table: "complaints",
                newName: "IX_complaints_ReplyID");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_complaints",
                table: "complaints",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_complaints_Comment_ReplyID",
                table: "complaints",
                column: "ReplyID",
                principalTable: "Comment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_users_Username",
                table: "Order",
                column: "Username",
                principalTable: "users",
                principalColumn: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_complaints_Comment_ReplyID",
                table: "complaints");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_complaints",
                table: "complaints");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "restaurants",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "menus",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "complaints",
                newName: "Complaints");

            migrationBuilder.RenameIndex(
                name: "IX_complaints_ReplyID",
                table: "Complaints",
                newName: "IX_Complaints_ReplyID");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Comment_ReplyID",
                table: "Complaints",
                column: "ReplyID",
                principalTable: "Comment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_Username",
                table: "Order",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username");
        }
    }
}
