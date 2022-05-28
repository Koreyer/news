namespace News.Api.A01.Foundation.DataHelpers
{
    public class ResultData<TApiEntity>
    {
        public int TotalCount { get; set; }
        public List<TApiEntity>? Datas { get; set; }
        
    }
}
