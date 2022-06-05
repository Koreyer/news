namespace News.Api.A03._01.Dto.Models
{
    public class CommentResult
    {
        public CommentDTO? Comment { get; set; }
        public List<CommentHistoryDTO> Historys { get; set; }
    }
}
