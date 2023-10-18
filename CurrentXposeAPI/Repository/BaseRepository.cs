using CurrentXposeAPI.Context;
using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrentXposeAPI.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected DbSet<T> DbSet;
        protected readonly CurrentXposeAPIContext _context;

        public BaseRepository(CurrentXposeAPIContext context) 
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Added;
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(object id) => await DbSet.FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync() => await DbSet.ToListAsync();

        public void SaveChanges() => SaveChangesAsync().Wait();

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public void Update(T entity) => _context.Entry<T>(entity).State = EntityState.Modified;
    }
}
