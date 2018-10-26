using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SieuThiMini.DAL.Entites
{
    public class SanPham
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string TenSanPham { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public int DonGia { get; set; }
        [Required]
        public string XuatXu { get; set; }

        public string DanhMucId { get; set; }
        public DanhMuc DanhMuc { get; set; }
    }
}
