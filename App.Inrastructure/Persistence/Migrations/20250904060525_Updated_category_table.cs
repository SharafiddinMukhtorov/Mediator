using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Inrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updated_category_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategorId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Cars",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategorId",
                table: "Cars",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CategorId",
                table: "Cars",
                newName: "IX_Cars_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cars",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Cars",
                newName: "CategorId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                newName: "IX_Cars_CategorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategorId",
                table: "Cars",
                column: "CategorId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
