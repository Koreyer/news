using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A02._01.News.Models;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._02.Dto.Services;
using News.Api.B01.BaseController;

namespace News.Api.B02.Controllers
{
    [Authorize(Roles = "管理员")]
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class ChanelController:BaseController<Chanel,ChanelDTO>
    {
        private readonly IApiService<Chanel, ChanelDTO> _apiService;
        public ChanelController(IApiService<Chanel, ChanelDTO> apiService) : base(apiService) { _apiService = apiService; }

    }
}
