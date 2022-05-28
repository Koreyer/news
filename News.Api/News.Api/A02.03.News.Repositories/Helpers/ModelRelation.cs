using Microsoft.EntityFrameworkCore;
using News.Api.A01.Foundation.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace News.Api.A02._03.News.Repositories.Helpers
{
    /// <summary>
    /// 领域模型数据处理的一些助理方法
    /// </summary>
    public static class ModelRelation
    {
        /// <summary>
        /// 提取包含属性的表达式
        /// </summary>
        /// <typeparam name="TDdo"></typeparam>
        /// <returns></returns>
        public static List<Expression<Func<TEntity, object>>> GetIncludeExpression<TEntity>() where TEntity : class, IData, new()
        {
            var result = new List<Expression<Func<TEntity, object>>>();

            PropertyInfo[] ddoPropertyCollection = typeof(TEntity).GetProperties();
            foreach (var ddoProperty in ddoPropertyCollection)
            {
                var ddoPropertyTypeName = ddoProperty.PropertyType.Name;
                var ddoPropertyTypeFullName = ddoProperty.PropertyType.FullName;

                if (ddoPropertyTypeFullName!.Contains("News.Models"))
                {
                    ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "i");
                    var property = Expression.Property(parameter, ddoProperty.Name);
                    var lambda = Expression.Lambda<Func<TEntity, object>>(property, parameter);
                    result.Add(lambda);
                }

            }
            return result;
        }

        public static void SetInclude<TEntity>(IQueryable<TEntity> dbSet) where TEntity : class, IData, new()
        {
            var includePropertyExpressionCollection = ModelRelation.GetIncludeExpression<TEntity>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }
        }
    }
}
