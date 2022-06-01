using News.Api.A01.Foundation.Data;

namespace News.Api.A03._01.Dto.Models
{
    public class CollectionDTO : Data
    {

        public string? AppUserId { get; set; }
        public string? AppUserName { get; set; }
        public string? NewsaId { get; set; }
        public string? NewsaName { get; set; }

    }
}
