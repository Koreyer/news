using Microsoft.EntityFrameworkCore;
using News.Api.A01.Foundation.Data;

namespace News.Api.A02._03.News.Repositories.Extenssion
{
    public static  class RepositoryExtenssion
    {
        /// <summary>
        /// 根据属性名称和对应的 Id，查找 DomainDataDbContext 中的对应的对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="domainRepository"></param>
        /// <param name="domainModelName"></param>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public static async Task<object> GetByDomainModelNameAndId<TEntity>(
            this IRepository<TEntity> domainRepository,
            string newsModelName,
            Guid objectId) where TEntity : class, IData, new()
        {
            var result = new object();
            var reposotory = domainRepository as Repository<TEntity>;

            var dbSetProperty = reposotory?.NewsContext.GetType().GetProperties().FirstOrDefault(x => x.Name == newsModelName);
            if (dbSetProperty != null)
            {
                var dbSet = dbSetProperty.GetValue(reposotory!.NewsContext) as IQueryable<IData>;

                if (dbSet != null)
                {
                    result = await dbSet.FirstOrDefaultAsync(x => x.Id == objectId);
                    return result! as object;
                }
            }
            return result! as object;
        }
    }
}
