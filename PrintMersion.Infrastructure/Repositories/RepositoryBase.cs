using Microsoft.EntityFrameworkCore;
using PrintMersion.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace PrintMersion.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity, TDbContext> : IRepository<TEntity> where TDbContext : DbContext where TEntity : class, new()
    {

        protected internal readonly TDbContext _context;

        protected internal readonly string _nameT;

        protected internal readonly bool _isPlural;





        public RepositoryBase(TDbContext context)
        {
            _context = context;
            _nameT = new TEntity().GetType().Name;
            _isPlural = _nameT.EndsWith("s");
        }


        public virtual async Task<bool> Delete(int id)
        {

            var currentPost = await Get(id);

            GetProperty().Remove(currentPost);

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {

            return await GetProperty().ToListAsync();

        }

        public virtual async Task<TEntity> Get(int id)
        {
            //return await GetProperty().FirstAsync<T>(o => (o.GetType().GetProperty("Id").GetValue(o) as int?) == id);
            //return await GetProperty().FirstOrDefaultAsync<T>(o => ((int)o.GetType().GetRuntimeProperty("Id").GetValue(o)) == id);
            return await GetProperty().FindAsync(id);
        }

        public virtual Task Patch(TEntity post)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Post(TEntity post)
        {
            await GetProperty().AddAsync(post);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Put(TEntity post)
        {
            var currentPost = await Get((int)post.GetType().GetProperty("Id").GetValue(post));
            await UpdateProperty(currentPost, post);
            return await _context.SaveChangesAsync() > 0;


        }

        protected virtual async Task<TEntity> UpdateProperty(TEntity current, TEntity uptadeEntity)
        {


            var properties = current.GetType().GetProperties();

            foreach (var item in properties)
            {
                string name = item.Name;

                if (name != "Id")
                {
                    item.SetValue(current, item.GetValue(name));
                }

            }

            return await Task.FromResult<TEntity>(current);






        }


        private DbSet<TEntity> GetProperty(bool IsLetterSnesesary = true)
        {

            var _contextType = _context.GetType();

            PropertyInfo _propertyInfo;

            if (!_isPlural || IsLetterSnesesary)
            {
                _propertyInfo = _contextType.GetProperty(_nameT + "s");


            }
            else
            {
                _propertyInfo = _contextType.GetProperty(_nameT);
            }

            var _value = _propertyInfo.GetValue(_context);
            return _value as DbSet<TEntity>;
        }
    }
}
