namespace News.Api.A02._01.News.Models
{
    /// <summary>
    /// 评论
    /// </summary>
    public class Comment:InteractBase
    {
        public DateTime Time { get; set; }
        //评论内容
        public string? Context { get; set; }
    }
}
