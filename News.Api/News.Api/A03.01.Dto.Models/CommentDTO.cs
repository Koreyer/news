using News.Api.A01.Foundation.Data;

namespace News.Api.A03._01.Dto.Models
{
    public class CommentDTO:Data
    {
        public string? AppUserId { get; set; }
        public string? AppUserName { get; set; }
        public string? NewsaId { get; set; }
        public string? NewsaName { get; set; }
        public DateTime Time { get; set; }
        //评论内容
        public string? Context { get; set; }
        public bool IsDeleted { get; set; }
    }
}
