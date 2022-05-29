using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A02._01.News.Models;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._02.Dto.Services;
using News.Api.B01.BaseController;

namespace News.Api.B02.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class FilesController:BaseController<Files,FilesDTO>
    {
        private readonly IWebHostEnvironment _env;
        public FilesController(IApiService<Files, FilesDTO> apiservice, IWebHostEnvironment env) : base(apiservice) { _env = env; }

        [AllowAnonymous]
        [HttpPost]
        public async Task<Result> FileUploadAsync(IFormFile file)
        {
            var dateName = DateTime.Now;
            string rootRoot = _env.ContentRootPath + @"\wwwroot\UploadFiles" + dateName.ToString("yyyyMMdd") + @"";
            //查看是否存在当天日期的文件夹
            if (!Directory.Exists(rootRoot))
            {
                Directory.CreateDirectory(rootRoot);
            }
            //后缀
            var fileSuffix = Path.GetExtension(file.FileName);
            //时间结尾的文件名
            var filePath = file.FileName.Substring(0, file.FileName.LastIndexOf('.')) + "_" + dateName.ToString("HHmmss") + fileSuffix;
            using (var systeam = System.IO.File.Create(rootRoot +"\\"+ filePath))
            {
                file.CopyTo(systeam);
            }
            var bo = new FilesDTO
            {
                Id = Guid.NewGuid(),
                Path = dateName.ToString("yyyyMMdd") + @"" + filePath
            };
            return await ApiService.AddAsync(bo);

        }
    }
}
