using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using SieuThiMini.Contract.DTOs;
using SieuThiMini.Contract.IServices;

namespace SieuThiMini.WebApi
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SanPhamController : Controller
    {
        private readonly ISanPhamService spserv;

        public SanPhamController(ISanPhamService sanPhamService)
        {
            spserv = sanPhamService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(spserv.GetSanPhams());
        }

        [HttpPost]
        public IActionResult Post([FromBody]string hash)
        {
            return Ok();
        }
    }
}