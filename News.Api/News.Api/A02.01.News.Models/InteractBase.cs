﻿using News.Api.A01.Foundation.Data;
using News.Api.A02._01.News.Models.AppIdentity;

namespace News.Api.A02._01.News.Models
{
    //点赞
    public class InteractBase : Data
    {
        public AppUser? User { get; set; }
        public Newsa? News { get; set; }
    }
}
