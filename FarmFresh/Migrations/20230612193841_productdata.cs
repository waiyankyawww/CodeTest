using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFresh.Migrations
{
    /// <inheritdoc />
    public partial class productdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    ShopByStore = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
