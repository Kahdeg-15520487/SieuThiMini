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
    class DanhMucService : IDanhMucService
    {
        private readonly SieuThiDbContext _context;

        public DanhMucService(SieuThiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DanhMucDTO> GetDanhMucs()
        {
            return _context.DanhMucs
                    .Include(dm => dm.SanPhams)
                    .ThenInclude(sp => sp.DanhMuc)
                    .Map().ToList();
        }

        public DanhMucDTO GetDanhMuc(string maDanhMuc)
        {
            var result = _context.DanhMucs
                        .Include(dm => dm.SanPhams)
                        .ThenInclude(sp => sp.DanhMuc)
                        .FirstOrDefault(dm => dm.Id.Equals(maDanhMuc));
            return result == null ? null : result.Map();
        }

        public bool CreateDanhMuc(DanhMucDTO dto)
        {
            var dm = dto.Map();
            try
            {
                _context.DanhMucs.Add(dm);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            return true;
        }

        public bool UpdateDanhMuc(DanhMucDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDanhMuc(string maDanhMuc)
        {
            throw new NotImplementedException();
        }
    }
}
