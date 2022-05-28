using News.Api.A02._01.News.Models;
using News.Api.A02._01.News.Models.AppIdentity;
using News.Api.A02._03.News.Repositories;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._01.Dto.Models.AppIdentity;
using News.Api.A03._02.Dto.Services;
using News.Api.A03._02.Dto.Services.Helpers;

namespace News.Api.C03.Helpers
{
    public static class InjectionHelp
    {
        public static void Injection(this IServiceCollection services)
        {

            #region 新闻频道
            services.AddScoped<IRepository<Chanel>, Repository<Chanel>>();
            services.AddScoped<IApiService<Chanel, ChanelDTO>, ApiService<Chanel, ChanelDTO>>();
            services.AddScoped<IMapperHelp<Chanel, ChanelDTO>, MapperHelp<Chanel, ChanelDTO>>();
            #endregion
            #region 用户
            services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();
            services.AddScoped<IApiService<AppUser, AppUserDTO>, ApiService<AppUser, AppUserDTO>>();
            services.AddScoped<IMapperHelp<AppUser, AppUserDTO>, MapperHelp<AppUser, AppUserDTO>>();
            #endregion
            #region 用户
            services.AddScoped<IRepository<Newsa>, Repository<Newsa>>();
            services.AddScoped<IApiService<Newsa, NewsaDTO>, ApiService<Newsa, NewsaDTO>>();
            services.AddScoped<IMapperHelp<Newsa, NewsaDTO>, MapperHelp<Newsa, NewsaDTO>>();
            #endregion
        }
    }
}
