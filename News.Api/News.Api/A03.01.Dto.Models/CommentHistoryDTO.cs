using News.Api.A01.Foundation.Data;

namespace News.Api.A03._01.Dto.Models
{
    public class CommentHistoryDTO:Data
    {

        public string? AppUserId { get; set; }
        public string? AppUserName { get; set; }
        public string? CommentId { get; set; }
        public string? CommentName { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string? Context { get; set; }
    }
}
