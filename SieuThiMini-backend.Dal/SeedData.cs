using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SieuThiMini.DAL
{
    class SeedData
    {
        public static readonly string danhmuc = "[{\"id\":\"dm01\",\"tenDanhMuc\":\"Sách\"},{\"id\":\"dm02\",\"tenDanhMuc\":\"Điện thoại\"},{\"id\":\"dm03\",\"tenDanhMuc\":\"Quần áo\"},{\"id\":\"dm05\",\"tenDanhMuc\":\"Trang sức\"}]";
        public static readonly string sanpham = "[{\"id\":\"fg\",\"tenSanPham\":\"fg\",\"soLuong\":4,\"donGia\":4,\"xuatXu\":\"f\",\"danhMucId\":\"dm01\"},{\"id\":\"er\",\"tenSanPham\":\"df\",\"soLuong\":5,\"donGia\":5,\"xuatXu\":\"fg\",\"danhMucId\":\"dm05\"},{\"id\":\"sp13\",\"tenSanPham\":\"Tivi lg\",\"soLuong\":15,\"donGia\":5000000,\"xuatXu\":\"Sony\",\"danhMucId\":\"dm01\"},{\"id\":\"sp0999\",\"tenSanPham\":\"Cẩm nang làm xau\",\"soLuong\":20,\"donGia\":20000,\"xuatXu\":\"Kim Đồng\",\"danhMucId\":\"dm01\"},{\"id\":\"sp103\",\"tenSanPham\":\"Dây chuyền bạc\",\"soLuong\":9,\"donGia\":500000,\"xuatXu\":\"Việt Nam\",\"danhMucId\":\"dm01\"},{\"id\":\"sp043\",\"tenSanPham\":\"Nokia1202\",\"soLuong\":30,\"donGia\":300000,\"xuatXu\":\"Trung Quốc\",\"danhMucId\":\"dm01\"},{\"id\":\"sp089\",\"tenSanPham\":\"Tivi\",\"soLuong\":15,\"donGia\":5000000,\"xuatXu\":\"Sony\",\"danhMucId\":\"dm01\"},{\"id\":\"sp109\",\"tenSanPham\":\"Dây chuyền bạc\",\"soLuong\":9,\"donGia\":500000,\"xuatXu\":\"Việt Nam\",\"danhMucId\":\"dm05\"},{\"id\":\"sp01\",\"tenSanPham\":\"Lập trình Windows nâng cao\",\"soLuong\":10,\"donGia\":10000,\"xuatXu\":\"HUI\",\"danhMucId\":\"dm01\"},{\"id\":\"sp02\",\"tenSanPham\":\"Cẩm nang làm đẹp\",\"soLuong\":20,\"donGia\":20000,\"xuatXu\":\"Kim Đồng\",\"danhMucId\":\"dm01\"},{\"id\":\"sp03\",\"tenSanPham\":\"iPhone5\",\"soLuong\":17,\"donGia\":14000000,\"xuatXu\":\"US\",\"danhMucId\":\"dm02\"},{\"id\":\"sp04\",\"tenSanPham\":\"Nokia1202\",\"soLuong\":30,\"donGia\":300000,\"xuatXu\":\"Trung Quốc\",\"danhMucId\":\"dm02\"},{\"id\":\"sp05\",\"tenSanPham\":\"Áo sơ mi nam\",\"soLuong\":50,\"donGia\":100000,\"xuatXu\":\"Việt Nam\",\"danhMucId\":\"dm03\"},{\"id\":\"sp06\",\"tenSanPham\":\"Quần Jeans\",\"soLuong\":24,\"donGia\":350000,\"xuatXu\":\"Việt Nam\",\"danhMucId\":\"dm03\"},{\"id\":\"sp09\",\"tenSanPham\":\"Mắt kính\",\"soLuong\":3,\"donGia\":25000000,\"xuatXu\":\"Việt Nam\",\"danhMucId\":\"dm05\"},{\"id\":\"sp10\",\"tenSanPham\":\"Dây chuyền bạc\",\"soLuong\":9,\"donGia\":500000,\"xuatXu\":\"Việt Nam\",\"danhMucId\":\"dm05\"}]";
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SieuThiDbContext>
    {
        public SieuThiDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SieuThiDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new SieuThiDbContext(builder.Options);
        }
    }
}
