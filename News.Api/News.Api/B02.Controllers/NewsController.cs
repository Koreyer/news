using Microsoft.AspNetCore.Mvc;
using News.Api.A02._01.News.Models;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._02.Dto.Services;
using News.Api.A03._02.Dto.Services.Helpers;
using News.Api.B01.BaseController;

namespace News.Api.B02.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class NewsController:BaseController<Newsa,NewsaDTO>
    {
        private readonly IApiService<Newsa, NewsaDTO> _apiService;
        public NewsController(IApiService<Newsa, NewsaDTO> apiService) : base(apiService) { _apiService = apiService; }
        [HttpPost]
        public async void  test(NewsaDTO userDTO)
        {
            //var a = _apiService.Repository.Context.Set<Chanel>().FirstOrDefault(x=>x.Id == Guid.Parse("efc4bfb6-4435-41dc-a666-08da38118312"));
            //var c = _apiService.Repository.Context.Set<Chanel>().Find(Guid.Parse(userDTO.ChanelId));
            //var a = new Newsa();
            //var b = _apiService.Mapper.Map<Newsa>(userDTO);
            //var b = _mapper.MapToEntityAsync(userDTO);
            //var c = _apiService.Context.Set<User>().Find(Guid.Parse(userDTO.UserId));
            //var b = _mapper.MapToEntity(userDTO, x => x.User);
            //var ac = await b;
            //var c = _apiService.AddAsync(userDTO,x=>x.User, x => x.Chanel, x => x.Files);
            //await  _apiService.AddAsync(userDTO);

        }
    }
}
