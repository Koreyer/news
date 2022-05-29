using News.Api.A01.Foundation.Data;

namespace News.Api.A03._01.Dto.Models
{
    public class FilesDTO : IData
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
    }
}
