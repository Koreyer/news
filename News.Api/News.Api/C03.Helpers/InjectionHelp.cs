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
            #region 新闻
            services.AddScoped<IRepository<Newsa>, Repository<Newsa>>();
            services.AddScoped<IApiService<Newsa, NewsaDTO>, ApiService<Newsa, NewsaDTO>>();
            services.AddScoped<IMapperHelp<Newsa, NewsaDTO>, MapperHelp<Newsa, NewsaDTO>>();
            #endregion

            services.AddScoped<IRepository<Files>, Repository<Files>>();
            services.AddScoped<IApiService<Files, FilesDTO>, ApiService<Files, FilesDTO>>();
            services.AddScoped<IMapperHelp<Files, FilesDTO>, MapperHelp<Files, FilesDTO>>();

            services.AddScoped<IRepository<Praise>, Repository<Praise>>();
            services.AddScoped<IApiService<Praise, PraiseDTO>, ApiService<Praise, PraiseDTO>>();
            services.AddScoped<IMapperHelp<Praise, PraiseDTO>, MapperHelp<Praise, PraiseDTO>>();



            services.AddScoped<IRepository<Collection>, Repository<Collection>>();
            services.AddScoped<IApiService<Collection, CollectionDTO>, ApiService<Collection, CollectionDTO>>();
            services.AddScoped<IMapperHelp<Collection, CollectionDTO>, MapperHelp<Collection, CollectionDTO>>();


            services.AddScoped<IRepository<Comment>, Repository<Comment>>();
            services.AddScoped<IApiService<Comment, CommentDTO>, ApiService<Comment, CommentDTO>>();
            services.AddScoped<IMapperHelp<Comment, CommentDTO>, MapperHelp<Comment, CommentDTO>>();


            services.AddScoped<IRepository<CommentHistory>, Repository<CommentHistory>>();
            services.AddScoped<IApiService<CommentHistory, CommentHistoryDTO>, ApiService<CommentHistory, CommentHistoryDTO>>();
            services.AddScoped<IMapperHelp<CommentHistory, CommentHistoryDTO>, MapperHelp<CommentHistory, CommentHistoryDTO>>();

            //CommentHistory
        }
    }
}
