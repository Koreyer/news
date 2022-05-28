using News.Api.A01.Foundation.Data;
using News.Api.A02._01.News.Models;

namespace News.Api.A03._01.Dto.Models
{
    public class NewsaDTO:Data
    {
        public DateTime Time { get; set; }
        public string? FilesId { get; set; }
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? ChanelId { get; set; }
        public string? ChanelName { get; set; }
    }
}
