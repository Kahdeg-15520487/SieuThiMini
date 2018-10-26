using System;
using System.Collections.Generic;
using System.Text;

namespace SieuThiMini.Contract.DTOs
{
    public class SanPhamDTO
    {
        public string MaSanPham { get; set; }

        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public string XuatXu { get; set; }

        public DanhMucDTO DanhMuc { get; set; }
    }
}
