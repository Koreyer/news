using News.Api.A01.Foundation.Data;
using News.Api.A02._01.News.Models.AppIdentity;

namespace News.Api.A02._01.News.Models
{
    /// <summary>
    /// 评论记录
    /// </summary>
    public class CommentHistory:Data
    {
        public AppUser? AppUser { get; set; }
        public Comment? Comment { get; set; }
        public DateTime Time { get; set; }
        public string? Context { get; set; }
    }
}
