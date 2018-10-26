using Microsoft.Extensions.DependencyInjection;
using SieuThiMini.AppService.Services;
using SieuThiMini.Contract.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SieuThiMini.AppService
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IDanhMucService, DanhMucService>();
            services.AddTransient<ISanPhamService, SanPhamService>();

            return services;
        }
    }
}
