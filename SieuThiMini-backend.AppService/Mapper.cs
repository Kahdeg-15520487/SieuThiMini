using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using SieuThiMini.Contract.DTOs;
using SieuThiMini.DAL.Entites;

namespace SieuThiMini.AppService
{
    static class Mapper
    {
        public static IEnumerable<DanhMucDTO> Map(this IEnumerable<DanhMuc> dms)
        {
            return dms.Select(dm => Map(dm));
        }

        public static DanhMucDTO Map(this DanhMuc dm)
        {
            return new DanhMucDTO()
            {
                MaDM = dm.Id,
                TenDanhMuc = dm.TenDanhMuc,
                SanPhams = dm.SanPhams.Map(false).ToArray()
            };
        }

        public static DanhMuc Map(this DanhMucDTO dmDTO)
        {
            return new DanhMuc()
            {
                Id = dmDTO.MaDM,
                TenDanhMuc = dmDTO.TenDanhMuc
            };
        }

        public static IEnumerable<SanPhamDTO> Map(this IEnumerable<SanPham> sps, bool isMapDanhMuc = true)
        {
            return sps.Select(sp => Map(sp, isMapDanhMuc));
        }

        public static SanPhamDTO Map(this SanPham sp, bool isMapDanhMuc = true)
        {
            return new SanPhamDTO()
            {
                MaSanPham = sp.Id,
                TenSanPham = sp.TenSanPham,
                SoLuong = sp.SoLuong,
                DonGia = sp.DonGia,
                XuatXu = sp.XuatXu,
                DanhMuc = isMapDanhMuc ? Map(sp.DanhMuc) : null
            };
        }

        public static SanPham Map(this SanPhamDTO spDTO)
        {
            return new SanPham()
            {
                Id = spDTO.MaSanPham,
                TenSanPham = spDTO.TenSanPham,
                SoLuong = spDTO.SoLuong,
                DonGia = spDTO.DonGia,
                XuatXu = spDTO.XuatXu,
                DanhMuc = spDTO.DanhMuc.Map()
            };
        }
    }
}
