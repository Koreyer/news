using Microsoft.AspNetCore.Identity;
using News.Api.A01.Foundation.Data;
using News.Api.A01.Foundation.Enum;
using System.ComponentModel.DataAnnotations;

namespace News.Api.A02._01.News.Models.AppIdentity
{
    public class AppUser: IdentityUser<Guid>,IData
    {
        //身份枚举
        public RoleTypeEnum RoleType { get; set; }
        public string? Name { get; set; }
        //性别
        public SexEnum Sex { get; set; }
        //生日
        public DateTime Birthday { get; set; }
        //创建时间
        public DateTime CreateTime { get; set; }
        //是否删除
        public bool IsDeleted { get; set; }

    }
}
