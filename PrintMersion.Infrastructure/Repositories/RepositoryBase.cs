using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

            GetProperty(_isPlural).Remove(currentPost);

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {

            return await GetProperty(_isPlural).ToListAsync();

        }

        public virtual async Task<TEntity> Get(int id)
        {
            //return await GetProperty().FirstAsync<T>(o => (o.GetType().GetProperty("Id").GetValue(o) as int?) == id);
            //return await GetProperty().FirstOrDefaultAsync<T>(o => ((int)o.GetType().GetRuntimeProperty("Id").GetValue(o)) == id);
            return await GetProperty(_isPlural).FindAsync(id);
        }

        public virtual Task Patch(TEntity post)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Post(TEntity post)
        {
            await GetProperty(_isPlural).AddAsync(post);
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
                    try
                    {
                        item.SetValue(current, item.GetValue(uptadeEntity));
                    }
                    catch (Exception non)
                    {

                  
                    }
                      
                    
                   
                }

            }

            return await Task.FromResult<TEntity>(current);

         




        }


        private DbSet<TEntity> GetProperty(bool IsLetterSnesesary = false)
        {

            var _contextType = _context.GetType();

            PropertyInfo _propertyInfo;

            if (!IsLetterSnesesary)
            {
                _propertyInfo = _contextType.GetProperty(_nameT + "s");


            }
            else
            {
                _propertyInfo = _contextType.GetProperty(_nameT);
            }

            var _value = ((DbSet<TEntity>)_propertyInfo.GetValue(_context)).AsQueryable(); ;

            foreach (var item in typeof(TEntity).GetProperties())
            {
                if (item.GetGetMethod().IsVirtual)
                {
                    _value.Include(item.Name);
                }

            }

            return (_value as DbSet<TEntity>);
        }
    }
}
