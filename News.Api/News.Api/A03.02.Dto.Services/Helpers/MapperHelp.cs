using AutoMapper;
using Microsoft.AspNetCore.Components;
using News.Api.A01.Foundation.Data;
using News.Api.A02._03.News.Repositories;
using News.Api.A02._03.News.Repositories.Extenssion;
using System.Linq.Expressions;
using System.Reflection;

namespace News.Api.A03._02.Dto.Services.Helpers
{
    public class MapperHelp<TEntity,TApiEntity>:IMapperHelp<TEntity,TApiEntity>
        where TEntity : class,IData,new()
        where TApiEntity : class,IData, new()
    {
        private readonly IRepository<TEntity> entityRepository;
        private readonly IMapper mapper;
        public IRepository< TEntity> EntityRepository => entityRepository;
        public IMapper Mapper => mapper;
        public MapperHelp(IRepository<TEntity> entityRepository,IMapper mapper)
        {
            this.entityRepository = entityRepository;
            this.mapper = mapper;
        }



        /// <summary>
        /// 对于没有关联关系的实体类的转换
        /// </summary>
        /// <param name="apiBo"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> MapToEntity(TApiEntity apiBo)
        {
            if(apiBo == null) return default(TEntity);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TApiEntity, TEntity>());
            return await Task.Run(()=>config.CreateMapper().Map<TEntity>(apiBo));
        }

        public virtual TApiEntity MapToApiEntity(TEntity bo)
        {
            if(bo == null) return default(TApiEntity);
            var config = new MapperConfiguration(cfg=>cfg.CreateMap<TEntity, TApiEntity>());
            return config.CreateMapper().Map<TApiEntity>(bo);
        }

        public static object CreateObject(Type type)
        {
            var newExpression = Expression.Lambda(Expression.New(type));
            var propertyDelegate = newExpression.Compile();//编译成委托
            var result = propertyDelegate.DynamicInvoke();
            return result;
        }



        public virtual async Task<TEntity> MapToEntityAsync(TApiEntity apiBo, params Expression<Func<TEntity, object>>[] args)
        {
            if (apiBo == null) return default(TEntity);
            var MCE = new MapperConfigurationExpression();
            var cfg = (MCE.CreateMap<TApiEntity, TEntity>());
            if (args != null)
            {
                foreach (var arg in args)
                {
                    dynamic result;
                    var propertyName = arg.Body.Type.Name + "Id";
                    var boId = Guid.Parse(apiBo.GetType().GetProperty(propertyName).GetValue(apiBo).ToString());
                    if (boId != Guid.Empty)
                    {
                        //获取EntityRepository的GetOtherBoAsync方法
                        var getOtherBoAsync = EntityRepository.GetType().GetMethod("GetOtherAsync");
                        //设置泛型类型
                        var generic = getOtherBoAsync.MakeGenericMethod(new Type[] { arg.Body.Type });
                        //调用方法并使用dynanic来接受Task<TOther>的返回
                        dynamic task = generic.Invoke(EntityRepository, new object[] { boId });
                        result = await task;
                    }// 数据库没有该条数据，用意可能是同时添加该条数据，所以创建一个新的对象
                    else
                    {
                        result = CreateObject(arg.Body.Type);
                        result.Id = Guid.NewGuid();
                    }
                    if (result == null)
                    {
                        result = CreateObject(arg.Body.Type);
                        result.Id = boId;
                    }



                    cfg.ForMember(arg, ops => ops.MapFrom(x => result));
                }
            }
            var config = new MapperConfiguration(MCE);
            var a = config.CreateMapper().Map<TEntity>(apiBo);
            return a;
        }

       


       

        
    }
}
