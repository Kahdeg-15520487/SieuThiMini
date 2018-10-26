using Microsoft.EntityFrameworkCore.Migrations;

namespace SieuThiMini.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TenDanhMuc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TenSanPham = table.Column<string>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<int>(nullable: false),
                    XuatXu = table.Column<string>(nullable: false),
                    DanhMucId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_DanhMucs_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMucs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DanhMucs",
                columns: new[] { "Id", "TenDanhMuc" },
                values: new object[,]
                {
                    { "dm01", "Sách" },
                    { "dm02", "Điện thoại" },
                    { "dm03", "Quần áo" },
                    { "dm05", "Trang sức" }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DanhMucId", "DonGia", "SoLuong", "TenSanPham", "XuatXu" },
                values: new object[,]
                {
                    { "fg", "dm01", 4, 4, "fg", "f" },
                    { "sp13", "dm01", 5000000, 15, "Tivi lg", "Sony" },
                    { "sp0999", "dm01", 20000, 20, "Cẩm nang làm xau", "Kim Đồng" },
                    { "sp103", "dm01", 500000, 9, "Dây chuyền bạc", "Việt Nam" },
                    { "sp043", "dm01", 300000, 30, "Nokia1202", "Trung Quốc" },
                    { "sp089", "dm01", 5000000, 15, "Tivi", "Sony" },
                    { "sp01", "dm01", 10000, 10, "Lập trình Windows nâng cao", "HUI" },
                    { "sp02", "dm01", 20000, 20, "Cẩm nang làm đẹp", "Kim Đồng" },
                    { "sp03", "dm02", 14000000, 17, "iPhone5", "US" },
                    { "sp04", "dm02", 300000, 30, "Nokia1202", "Trung Quốc" },
                    { "sp05", "dm03", 100000, 50, "Áo sơ mi nam", "Việt Nam" },
                    { "sp06", "dm03", 350000, 24, "Quần Jeans", "Việt Nam" },
                    { "er", "dm05", 5, 5, "df", "fg" },
                    { "sp109", "dm05", 500000, 9, "Dây chuyền bạc", "Việt Nam" },
                    { "sp09", "dm05", 25000000, 3, "Mắt kính", "Việt Nam" },
                    { "sp10", "dm05", 500000, 9, "Dây chuyền bạc", "Việt Nam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_DanhMucId",
                table: "SanPhams",
                column: "DanhMucId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "DanhMucs");
        }
    }
}
