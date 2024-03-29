﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A01.Foundation.Enum;
using News.Api.A01.Foundation.Tools;
using News.Api.A02._01.News.Models;
using News.Api.A02._01.News.Models.AppIdentity;
using News.Api.A02._03.News.Repositories;
using News.Api.A03._01.Dto.Models;
using News.Api.A03._01.Dto.Models.AppIdentity;
using News.Api.A03._02.Dto.Services;
using News.Api.A03._02.Dto.Services.Helpers;
using News.Api.B01.BaseController;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace News.Api.B02.Controllers
{
    
    [ApiController]
    [Route("Api/[controller]/[action]")]
    public class UserController:BaseController<AppUser, AppUserDTO>
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IRepository<AppUser> _repository;
        public UserController(IApiService<AppUser, AppUserDTO> apiService, IConfiguration configuration) : base(apiService) 
        { 
            _configuration = configuration;
            _mapper = ApiService.Mapper.Mapper;
            _repository = ApiService.Repository;
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<SecurityToken> Login(AppUserDTO userDTO)
        {
            var resultData = new Result();
            var pass = BaseFunction.MD5Encrypt32(userDTO.PasswordHash);
            var loginUser = await ApiService.GetAsync(x=>x.PhoneNumber == userDTO.PhoneNumber && x.PasswordHash == pass && x.IsDeleted == false);
            if (loginUser != null)
            {
                resultData.Message = "登录成功";
                resultData.ResultEnum = ResultEnum.操作成功;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var jwt = new SecurityTokenDescriptor
                {
                    Issuer = _configuration["JWT:Issuer"],
                    Audience = _configuration["JWT:Audience"],
                    Subject = new ClaimsIdentity(new[]
                       {
                        new Claim("id", loginUser.Id.ToString()),
                        new Claim("name", loginUser.UserName),
                        new Claim(ClaimTypes.Role, loginUser.RoleTypeName)
                        }),
                    //有效时间
                    Expires = DateTime.Now.AddDays(30),
                    SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                };
                SecurityToken securityToken = new JwtSecurityTokenHandler().CreateToken(jwt);
                return securityToken;
            }
            else
            {
                resultData.Message = "账号或者密码错误";
                resultData.ResultEnum = ResultEnum.操作失败;
                return new JwtSecurityTokenHandler().CreateToken(new SecurityTokenDescriptor { Issuer = "登录失败" });
            }
        }
        
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="appUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<Result> Logon(AppUserDTO appUserDTO)
        {
            var user = await ApiService.GetAsync(x => x.PhoneNumber == appUserDTO.PhoneNumber);
            if(user == null)
            {
                appUserDTO.PasswordHash = BaseFunction.MD5Encrypt32(appUserDTO.PasswordHash);
                appUserDTO.CreateTime = DateTime.Now;
                return await _repository.AddAsync(_mapper.Map<AppUser>(appUserDTO));
            }
            else
            {
                return new Result() { };
            }
            
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "管理员")]
        public async Task<Result> Delete(string  id)
        {
            var result = new Result();
            var guid = Guid.Empty;
            if(Guid.TryParse(id,out guid))
            {
                var user = await ApiService.GetAsync(guid);
                user.IsDeleted = true;
                result =  await ApiService.UpdateAsync(user);
                result.Message = "删除成功";
                return result;
            }
            result.Message = "删除失败";
            return result;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="appUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<Result> PassEdit(AppUserDTO appUserDTO)
        {
            var resultData = new Result();
            var loginUser = await ApiService.GetAsync(appUserDTO.Id);
            loginUser.PasswordHash = BaseFunction.MD5Encrypt32(appUserDTO.PasswordHash);
            if (loginUser != null)
            {
                return await ApiService.UpdateAsync(loginUser);
            }
            return resultData;
        }
        
    }
}
