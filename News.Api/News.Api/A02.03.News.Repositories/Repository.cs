using Microsoft.EntityFrameworkCore;
using News.Api.A01.Foundation.Data;
using News.Api.A01.Foundation.DataHelpers;
using News.Api.A01.Foundation.Enum;
using News.Api.A02._02.News.ORM;
using News.Api.A02._03.News.Repositories.Helpers;
using System.Linq.Expressions;

namespace News.Api.A02._03.News.Repositories
{
    /// <summary>
    /// 针对仓储泛型接口 <see cref="IRepository{TEntity}" /> 的具体实现。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IData, new()
    {
        /// <summary>
        /// EF 中实现领域模型对象和关系数据库表对象映射关联上下文对象
        /// </summary>
        private readonly NewsContext _context;
        internal NewsContext NewsContext { get { return _context; } }
        public  NewsContext Context { get=>_context; }
        public Repository(NewsContext context) {
            _context = context;
        }
        public async Task<Result> AddAsync(TEntity ddo)
        {

            var result = new Result()
            {
                Message = "新增失败",
                ResultEnum = ResultEnum.操作失败,
                Status = 500

            };
            try
            {
                 _context.Set<TEntity>().Add(ddo);
                await _context.SaveChangesAsync();
                result.Status = 200;
                result.Message = "新增成功";
                result.ResultEnum = ResultEnum.操作成功;
                return result;
            }
            catch 
            {

                return result;
            }
        }

        public async Task<Result> AddTOherAsync<TOher>(TOher oher)
            where TOher : class, IData, new()
        {
            var result = new Result()
            {
                Message = "新增失败",
                ResultEnum = ResultEnum.操作失败,
                Status = 500

            };
            try
            {
                _context.Set<TOher>().Add(oher);
                await _context.SaveChangesAsync();
                result.Status = 200;
                result.Message = "新增成功";
                result.ResultEnum = ResultEnum.操作成功;
                return result;
            }
            catch
            {

                return result;
            }
        }

        public async Task<int> CountAsync()  => await _context.Set<TEntity>()!.CountAsync();

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>()!.Where(predicate).CountAsync();

        public async Task<Result> DeleteAsync(Guid id)
        {
            var result = new Result()
            {
                Message = "删除失败",
                ResultEnum = ResultEnum.操作失败

            };
            var ddo = await _context!.Set<TEntity>()!.FindAsync(id);
            if (ddo == null)
                return result;
            else
            {
                try
                {
                    _context.Set<TEntity>().Remove(ddo);
                    await _context.SaveChangesAsync();
                    result.Message = "删除成功";
                    result.ResultEnum = ResultEnum.操作成功;
                    result.Status = 200;
                    return result;
                }
                catch
                {
                    return result;
                }
            }
        }

        public async Task<ResultData<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> dbSet = _context!.Set<TEntity>();
            var includePropertyExpressionCollection = ModelRelation.GetIncludeExpression<TEntity>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }
            var result = new ResultData<TEntity>() { Datas = await dbSet!.ToListAsync(),TotalCount = await dbSet!.CountAsync()};
            return result!;
        }

        public async Task<ResultData<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> dbSet = _context!.Set<TEntity>();
            var includePropertyExpressionCollection = ModelRelation.GetIncludeExpression<TEntity>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }

            var result = new ResultData<TEntity>() { Datas = await dbSet!.Where(predicate).ToListAsync(), TotalCount = await dbSet!.CountAsync() };
            return result!;
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            IQueryable<TEntity> dbSet = _context!.Set<TEntity>();
            var includePropertyExpressionCollection = ModelRelation.GetIncludeExpression<TEntity>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }
            var result = await dbSet!.FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }

        public async Task<Other> GetOtherAsync<Other>(Guid id)
            where Other : class,IData,new()
        {
            var result =  _context.Set<Other>().Find(id);
            return result!;
        }
        public  Other GetOther<Other>(Guid id)
            where Other : class, IData, new()
        {
            var result = _context.Set<Other>().Find(id);
            return result!;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> dbSet = _context!.Set<TEntity>();
            var includePropertyExpressionCollection = ModelRelation.GetIncludeExpression<TEntity>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }

            var result = await dbSet!.FirstOrDefaultAsync(predicate);
            return result!;
        }
        /// <summary>
        /// 根据查询条件，获取仓储中满足条件，并且按照给定批次（页码）、批量（每页条数）返回的领域对象集合
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="start">起始索引</param>
        /// <param name="length">数量</param>
        /// <returns></returns>
        public async Task<ResultData<TEntity>> GetBySelectAsync(int start, int length, Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> dbSet = _context!.Set<TEntity>();
            var includePropertyExpressionCollection = ModelRelation.GetIncludeExpression<TEntity>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }
            if(predicate != null)
            {
                var total = await dbSet!.CountAsync();
                if (length < 1)
                    length = 100;
                var datas = await dbSet.Where(predicate).Skip(start).Take(length).ToListAsync();
                return new ResultData<TEntity>() { TotalCount = total, Datas = datas };
            }
            else
            {
                var total = await dbSet!.CountAsync();
                if (length < 1)
                    length = 100;
                var datas = await dbSet.Skip(start).Take(length).ToListAsync();
                return new ResultData<TEntity>() { TotalCount = total, Datas = datas };
            }
            
        }

        public async Task<bool> HasAsync(Guid id) => await _context.Set<TEntity>()!.AnyAsync(x => x.Id == id);

        public async Task<Result> UpdateAsync(TEntity ddo)
        {
            var result = new Result()
            {
                Message = "这条Id没有数据",
                ResultEnum = ResultEnum.操作失败,
                Status = 400
                
           };
            if (!await _context.Set<TEntity>().AnyAsync(x=>x.Id == ddo.Id))
                return result;
            else
            {
                try
                {
                    if (_context.ChangeTracker.Entries<TEntity>().Any(x => x.Entity.Id.Equals(ddo.Id)))
                    {
                        var trackingBo = _context.ChangeTracker.Entries<TEntity>().AsQueryable().Where(x => x.Entity.Id.Equals(ddo.Id)).FirstOrDefault();
                        trackingBo.State = EntityState.Detached;
                    }
                    _context.Set<TEntity>().Update(ddo);
                    await _context.SaveChangesAsync();
                    result.Message = "更新成功";
                    result.ResultEnum = ResultEnum.操作成功;
                    result.Status = 200;
                    return result;
                }
                catch
                {
                    result.Message = "更新失败";
                    result.Status = 500;
                    return result;
                }
            }
        }
        public async Task<Result> UpdateTOherAsync<TOher>(TOher oher)
            where TOher : class,IData,new()
        {
            var result = new Result()
            {
                Message = "这条Id没有数据",
                ResultEnum = ResultEnum.操作失败,
                Status = 400

            };
            if (!await _context.Set<TOher>().AnyAsync(x => x.Id == oher.Id))
                return result;
            else
            {
                try
                {
                    if (_context.ChangeTracker.Entries<TOher>().Any(x => x.Entity.Id.Equals(oher.Id)))
                    {
                        var trackingBo = _context.ChangeTracker.Entries<TOher>().AsQueryable().Where(x => x.Entity.Id.Equals(oher.Id)).FirstOrDefault();
                        trackingBo.State = EntityState.Detached;
                    }
                    _context.Set<TOher>().Update(oher);
                    await _context.SaveChangesAsync();
                    result.Message = "更新成功";
                    result.ResultEnum = ResultEnum.操作成功;
                    result.Status = 200;
                    return result;
                }
                catch
                {
                    result.Message = "更新失败";
                    result.Status = 500;
                    return result;
                }
            }
        }
    }
}
