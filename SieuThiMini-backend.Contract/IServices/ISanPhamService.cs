using SieuThiMini.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SieuThiMini.Contract.IServices
{
    public interface ISanPhamService
    {
        IEnumerable<SanPhamDTO> GetSanPhams();
        SanPhamDTO GetSanPham(string maSanPham);

        bool CreateSanPham(SanPhamDTO dto);
        bool UpdateSanPham(SanPhamDTO dto);
        bool DeleteSanPham(string maSanPham);
    }
}
