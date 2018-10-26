using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using SieuThiMini.Contract.DTOs;
using SieuThiMini.Contract.IServices;
using SieuThiMini.DAL;

namespace SieuThiMini.AppService.Services
{
    class SanPhamService : ISanPhamService
    {
        private readonly SieuThiDbContext _context;

        public SanPhamService(SieuThiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SanPhamDTO> GetSanPhams()
        {
            return _context.SanPhams
                    .Include(sp => sp.DanhMuc)
                    .Map().ToList();
        }

        public SanPhamDTO GetSanPham(string maSanPham)
        {
            var result = _context.SanPhams
                        .Include(sp => sp.DanhMuc)
                        .FirstOrDefault(sp => sp.Id.Equals(maSanPham));
            return result == null ? null : result.Map();
        }

        public bool CreateSanPham(SanPhamDTO dto)
        {
            var sp = dto.Map();
            try
            {
                _context.SanPhams.Add(sp);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

            return true;
        }

        public bool UpdateSanPham(SanPhamDTO dto)
        {
            var oldSanPham = _context.SanPhams
                    .Include(sp => sp.DanhMuc)
                    .FirstOrDefault(sp => sp.Id.Equals(dto.MaSanPham));

            if (oldSanPham == null)
            {
                throw new KeyNotFoundException(dto.MaSanPham);
            }

            oldSanPham.TenSanPham = dto.TenSanPham;
            oldSanPham.SoLuong = dto.SoLuong;
            oldSanPham.DonGia = dto.DonGia;
            oldSanPham.XuatXu = dto.XuatXu;
            oldSanPham.DanhMucId = dto.DanhMuc.MaDM;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

            return true;
        }

        public bool DeleteSanPham(string maSanPham)
        {
            var oldSanPham = _context.SanPhams
                    .Include(sp => sp.DanhMuc)
                    .FirstOrDefault(sp => sp.Id.Equals(maSanPham));

            if (oldSanPham == null)
            {
                throw new KeyNotFoundException(maSanPham);
            }

            _context.Remove(oldSanPham);

            try
            {
                _context.SaveChanges();
            }
            catch  (Exception ex)
            {
                throw new ArgumentException(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

            return true;
        }
    }
}
