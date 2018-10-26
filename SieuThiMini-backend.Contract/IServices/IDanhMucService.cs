using SieuThiMini.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SieuThiMini.Contract.IServices
{
    public interface IDanhMucService
    {
        IEnumerable<DanhMucDTO> GetDanhMucs();
        DanhMucDTO GetDanhMuc(string maDanhMuc);

        bool CreateDanhMuc(DanhMucDTO dto);
        bool UpdateDanhMuc(DanhMucDTO dto);
        bool DeleteDanhMuc(string maDanhMuc);
    }
}
