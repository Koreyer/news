using News.Api.A01.Foundation.Data;
using News.Api.A01.Foundation.Enum;

namespace News.Api.A03._01.Dto.Models.AppIdentity
{
    public class AppUserDTO:IData
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        //身份枚举
        public RoleTypeEnum RoleType { get; set; }
        public string? RoleTypeName { get; set; }        
        //性别
        public SexEnum Sex { get; set; }
        public string? SexName { get; set; }
        //生日
        public DateTime Birthday { get; set; }
        //创建时间
        public DateTime CreateTime { get; set; }
        //是否删除
        public bool IsDeleted { get; set; }

        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
