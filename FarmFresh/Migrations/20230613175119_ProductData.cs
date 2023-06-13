using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFresh.Migrations
{
    /// <inheritdoc />
    public partial class ProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    ShopByStore = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Product");
        }
    }
}
