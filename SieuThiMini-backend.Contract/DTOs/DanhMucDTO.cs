using System;
using System.Collections.Generic;
using System.Text;

namespace SieuThiMini.Contract.DTOs
{
    public class DanhMucDTO
    {
        public string MaDM { get; set; }

        public string TenDanhMuc { get; set; }

        public SanPhamDTO[] SanPhams { get; set; }
    }
}
