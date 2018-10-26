using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SieuThiMini.DAL.Entites
{
    public class DanhMuc
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string TenDanhMuc { get; set; }
        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}
