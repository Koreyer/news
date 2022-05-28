using News.Api.A01.Foundation.Enum;

namespace News.Api.A01.Foundation.DataHelpers
{
    public class Result
    {
        public ResultEnum ResultEnum { get; set; }
        public string? Message { get; set; }
        public int Status { get; set; }
        public object? Data { get; set; }
    }
}
