using News.Api.A01.Foundation.Data;
using News.Api.A02._01.News.Models.AppIdentity;

namespace News.Api.A02._01.News.Models
{
    //新闻
    public class Newsa:Data
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 标题图片
        /// </summary>
        public Files? Files { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 发布人
        /// </summary>
        public AppUser? AppUser { get; set; }
        /// <summary>
        /// 频道
        /// </summary>
        public Chanel? Chanel { get; set; }
        /// <summary>
        /// 点赞
        /// </summary>
        public int CommentCount { get; set; }
        /// <summary>
        /// 收藏
        /// </summary>
        public int CollectionCount { get; set; }
        /// <summary>
        /// 访问
        /// </summary>
        public int AccessCount { get; set; }
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }

    }
}
