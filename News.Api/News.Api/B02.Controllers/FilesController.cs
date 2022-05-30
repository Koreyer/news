using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A02._01.News.Models;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._02.Dto.Services;
using News.Api.B01.BaseController;

namespace News.Api.B02.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class FilesController:BaseController<Files,FilesDTO>
    {
        private readonly IWebHostEnvironment _env;
        public FilesController(IApiService<Files, FilesDTO> apiservice, IWebHostEnvironment env) : base(apiservice) { _env = env; }

        [HttpPost]
        public async Task<Result> FileUploadAsync(IFormFile file)
        {
            var dateName = DateTime.Now;
            string rootRoot = _env.WebRootPath;
            try
            {
                var path = $"/UploadFiles/{dateName:yyyyMMdd}/";
                //查看是否存在当天日期的文件夹
                if (!Directory.Exists(rootRoot + path))
                {
                    Directory.CreateDirectory(rootRoot + path);
                }
                //后缀
                var fileSuffix = Path.GetExtension(file.FileName);
                //时间结尾的文件名
                var filePath = file.FileName.Substring(0, file.FileName.LastIndexOf('.')) + "_" + dateName.ToString("HHmmss") + fileSuffix;

                //完整的文件路径
                var completeFilePath = Path.Combine(path, filePath);


                using (var systeam = System.IO.File.Create(rootRoot + path + filePath))
                {
                    await file.CopyToAsync(systeam);
                    await systeam.FlushAsync();
                }
                var bo = new FilesDTO
                {
                    Id = Guid.NewGuid(),
                    Path = completeFilePath
                };
                return await ApiService.AddAsync(bo);
            }
            catch (Exception)
            {

                throw;
            }
           

        }
        /// <summary>
        /// 根据Id返回文件流
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet]
        public async Task<MemoryStream> GetFileById(Guid id)
        {
            var currentDate = DateTime.Now;
            var webRootPath = _env.WebRootPath;//>>>相当于HttpContext.Current.Server.MapPath("") 

            var file = await ApiService.GetAsync(id);
            if (file == null) return null;
            var imgPath = webRootPath +"\\"+ file.Path;
            try
            {
                var imgStream = new MemoryStream(System.IO.File.ReadAllBytes(imgPath));
                return imgStream;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            //从图片中读取流
        }
        /// <summary>
        /// 根据Id返回文件路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetPathById(Guid id)
        {
            var file = await ApiService.GetAsync(id);
            return file == null ? null : _env.WebRootPath+file.Path;
        }

    }
}
