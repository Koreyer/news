using News.Api.A01.Foundation.Data;
using News.Api.A02._01.News.Models.AppIdentity;

namespace News.Api.A02._01.News.Models
{
    //新闻
    public class Newsa:Data
    {
        //创建时间
        public DateTime Time { get; set; }
        //标题图片
        public Files? Files { get; set; }
        //内容
        public string? Content { get; set; }
        //发布人
        public AppUser? AppUser { get; set; }
        //频道
        public Chanel? Chanel { get; set; }

    }
}
