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

        
        public virtual async Task<List<TApiEntity>> MapToApiEntitysAsync(List<TEntity> ddos)
        {
            var dtos = new List<TApiEntity>();
            foreach (var ddo in ddos)
            {
                var dto = await MapToApiEntityAsync(ddo);
                dtos.Add(dto);
            }
            return dtos;
        }

        public virtual async Task<TApiEntity> MapToApiEntityAsync(TEntity ddo)
        {
            var dto = new TApiEntity();
            // 提取领域对象模型的属性
            PropertyInfo[] ddoPropertyCollection = typeof(TEntity).GetProperties();
            // 提取传输对象模型的属性
            PropertyInfo[] dtoPropertyCollection = typeof(TApiEntity).GetProperties();

            if (ddo == null)
                return dto;
            else
            {
                foreach (var ddoProperty in ddoPropertyCollection)
                {
                    // 获取领域对象模型属性名称
                    var ddoPropertyTypeName = ddoProperty.PropertyType.Name;
                    // 获取领域对象模型属性的全名
                    var ddoPropertyTypeFullName = ddoProperty.PropertyType.FullName;

                    // 先处理简单的属性，如果全名中不包含 “News.Models” 则认为是简单属性
                    if (!ddoPropertyTypeFullName!.Contains("News.Models"))
                    {
                        // 根据简单属性同名映射原则，获取传输对象模型属性
                        var dtoProperty = dtoPropertyCollection.FirstOrDefault(x => x.Name == ddoProperty.Name);
                        if (dtoProperty != null)
                        {
                            // 提取领域对象模型属性的值
                            var ddoPropertyValue = ddoProperty.GetValue(ddo);
                            // 赋值给传输对象模型属性
                            dtoProperty.SetValue(dto, ddoPropertyValue);
                        }
                    }
                    else
                    {
                        if (ddoPropertyTypeFullName.Contains("News.Models"))
                        {
                            // 先处理可能的 Parent
                            if (ddoPropertyTypeName == typeof(TEntity).Name && ddoProperty.Name == "Parent")
                            {
                                var ddoPropertyValue = ddoProperty.GetValue(ddo) as TEntity;
                                if (ddoPropertyValue != null)
                                {
                                    // 为传输的默认属性 ParentId, ParentName 赋值
                                    var dtoPrentId = ddoPropertyCollection.FirstOrDefault(x => x.Name == "ParentId");
                                    if (dtoPrentId != null)
                                        dtoPrentId.SetValue(dto, ddoPropertyValue.Id);

                                    var dtoPrentName = dtoPropertyCollection.FirstOrDefault(x => x.Name == "ParentName");
                                    if (dtoPrentName != null)
                                    {
                                        var nameProperty = ddoPropertyValue.GetType().GetProperty("Name");
                                        if (nameProperty != null)
                                        {
                                            dtoPrentName.SetValue(dto, nameProperty.GetValue(ddoPropertyValue));
                                        }

                                    }

                                }
                            }
                            else
                            {
                                // 处理其他的导航属性的值
                                var ddoPropertyValue = ddoProperty.GetValue(ddo) as IData;
                                if (ddoPropertyValue != null)
                                {
                                    // 提取传输对象关联的 Id 的属性
                                    var dtoPropertyForId = dtoPropertyCollection.FirstOrDefault(x => x.Name == ddoProperty.Name + "Id");
                                    if (dtoPropertyForId != null)
                                    {
                                        dtoPropertyForId.SetValue(dto, ddoPropertyValue.Id);
                                    }
                                    // 提传输端关联的 Id 的属性
                                    var dtoPropertyForName = dtoPropertyCollection.FirstOrDefault(x => x.Name == ddoProperty.Name + "Name");
                                    if (dtoPropertyForName != null)
                                    {
                                        dtoPropertyForName.SetValue(dto, ddoPropertyValue.Name);
                                    }
                                }
                            }
                        }
                    }
                }
                return dto;

            }
        }


       

        
    }
}
