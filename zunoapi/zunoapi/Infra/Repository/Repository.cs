using Microsoft.EntityFrameworkCore;
using zunoapi.Infra.Context;
using zunoapi.Infra.Interface;

namespace zunoapi.Infra.Repository
{
  
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ZunoContext _context;  //referência ao contexto do banco de dados
        protected readonly DbSet<T> _dbSet;       //referência ao conjunto de entidades do tipo T que serão manipuladas

        public Repository(ZunoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}