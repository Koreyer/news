﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A01.Foundation.Tools;
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

        //[Authorize(Roles = "发布社")]
        public override Task<Result> AddAsync(NewsaDTO apiEntity)
        {
            return _apiService.AddAsync(apiEntity,x=>x.AppUser, x => x.Chanel, x => x.Files);
        }

        public override async Task<ResultData<NewsaDTO>> GetBySelectAsync([FromBody] SelectParameter selectParameter)
        {
            if (!string.IsNullOrEmpty(selectParameter.SelectValue) && !string.IsNullOrEmpty(selectParameter.ChanelId))
            {
                return await _apiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length, x => x.Name.Contains(selectParameter.SelectValue) && x.Chanel.Id == Guid.Parse(selectParameter.ChanelId));
            }else if (!string.IsNullOrEmpty(selectParameter.SelectValue))
            {
                return await _apiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length, x => x.Name.Contains(selectParameter.SelectValue));
            }
            else if (!string.IsNullOrEmpty(selectParameter.ChanelId))
            {
                return await _apiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length, x => x.Chanel.Id == Guid.Parse(selectParameter.ChanelId));
            }
            else
            {
                return await _apiService.GetBySelectAsync(selectParameter.Start, selectParameter.Length,null);
            }
        }

    }
}
