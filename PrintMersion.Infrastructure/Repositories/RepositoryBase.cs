using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrintMersion.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq;

namespace PrintMersion.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity,TDbContext> : IRepository<TEntity> where TDbContext : DbContext where TEntity :class, new()
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


        public virtual async Task Delete(TEntity post)
        {
            GetProperty().Remove(post);
           await _context.SaveChangesAsync();
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

        public virtual async Task Post(TEntity post)
        {
            await GetProperty().AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Put(TEntity post)
        {
            GetProperty().Update(post);
            await _context.SaveChangesAsync();
        

        }



        private DbSet<TEntity> GetProperty()
        {
            if (_isPlural)
            {



                var _contextType = _context.GetType();
                var _propertyInfo = _contextType.GetProperty(_nameT);
                var _value = _propertyInfo.GetValue(_context, new object[] { });
                return _value as DbSet<TEntity>;

            }
            else
            {
                var _contextType = _context.GetType();
                var _propertyInfo = _contextType.GetProperty(_nameT + "s");
                var _value = _propertyInfo.GetValue(_context, new object[] { });
                return _value as DbSet<TEntity>;
            }
        }
    }
}
