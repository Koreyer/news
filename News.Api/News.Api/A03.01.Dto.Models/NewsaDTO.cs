using News.Api.A01.Foundation.Data;
using News.Api.A02._01.News.Models;

namespace News.Api.A03._01.Dto.Models
{
    public class NewsaDTO:Data
    {
        public DateTime Time { get; set; }
        public string? FilesId { get; set; }
        public string? Content { get; set; }
        public string? AppUserId { get; set; }
        public string? AppUserName { get; set; }
        public string? ChanelId { get; set; }
        public string? ChanelName { get; set; }
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

        public bool IsDelete { get; set; }
    }
}
