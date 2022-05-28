using AutoMapper;
using News.Api.A02._01.News.Models;
using News.Api.A02._01.News.Models.AppIdentity;
using News.Api.A02._02.News.ORM;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._01.Dto.Models.AppIdentity;

namespace News.Api.A03._02.Dto.Services.Helpers
{
    public class MapperProfile : Profile
    {
        //创建个构造函数
        public MapperProfile()
        {
            //将某些枚举啊你懂的技术问题放这里吧
            //创建Map,左边是实体模型类，右边是DTO
            CreateMap<AppUser, AppUserDTO>().ForMember(x => x.SexName, y => y.MapFrom(a => a.Sex)).ForMember(x => x.RoleTypeName, y => y.MapFrom(a => a.RoleType));
            CreateMap<AppUserDTO, AppUser>().ForMember(x => x.Sex, y => y.MapFrom(a => a.SexName)).ForMember(x => x.RoleType, y => y.MapFrom(a => a.RoleTypeName));
        }

    }
}
