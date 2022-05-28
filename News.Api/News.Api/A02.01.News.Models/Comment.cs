namespace News.Api.A02._01.News.Models
{
    public class Comment:InteractBase
    {
        public DateTime Time { get; set; }
        //评论内容
        public string? Context { get; set; }
    }
}
