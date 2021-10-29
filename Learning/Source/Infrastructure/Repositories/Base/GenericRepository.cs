using Domain.Interfaces;
using Domain.Interfaces.Base;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    /// <summary>
    /// In the instruction
    /// https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
    /// Don't use Async method
    /// https://codewithmukesh.com/blog/razor-page-crud-in-aspnet-core/
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        #region Constructor
        //ApplicationContext in ApplicationLayer so Remember to Add Project Reference to Application
        protected readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region NonAsync Method

        public void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }
        //Temporary Comment for later use
        //public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        //{
        //    return _context.Set<T>().Where(expression);
        //}

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            if(_context.Set<TEntity>().Find(id)!=null)
            return _context.Set<TEntity>().Find(id);
            else throw new ArgumentNullException(nameof(TEntity));
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        #endregion

        #region Async Method
        public virtual async Task<TEntity> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            if (await _context.Set<TEntity>().FindAsync(id) == null)
            {
                return null;
            }
            else
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }

            
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        public Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }
        //public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        //{
        //    return await _context.Set<TEntity>().ToListAsync();
        //}
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        #endregion
    }
}
