using News.Api.A01.Foundation.Data;
using News.Api.A02._01.News.Models.AppIdentity;

namespace News.Api.A02._01.News.Models
{
    //点赞
    public class InteractBase : Data
    {
        public AppUser? AppUser { get; set; }
        public Newsa? Newsa { get; set; }
    }
}
