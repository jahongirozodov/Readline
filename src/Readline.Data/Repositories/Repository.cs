using Microsoft.EntityFrameworkCore;
using Readline.Data.Contexts;
using Readline.Data.IRepositories;
using Readline.Domain.Commons;
using System.Linq.Expressions;

namespace Readline.Data.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<T> dbSet;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        this.dbSet = appDbContext.Set<T>();
    }
    public async Task CreateAsync(T entity)
        => await this.dbSet.AddAsync(entity);
    public void Update(T entity)
        => dbSet.Entry(entity).State = EntityState.Modified;

    public void Delete(T entity)
        => entity.IsDeleted = true;

    public void Destroy(T entity)
        => this.dbSet.Remove(entity);

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool IsNoTracked = true, string[] includes = null)
    {
        IQueryable<T> query = expression is null? dbSet.AsQueryable() : dbSet.Where(expression);
        
        query = IsNoTracked is true? query : query.AsNoTracking();

        if(includes is not null)
            foreach(string include in includes)
                query.Include(include); 

        return query.Where(x=> !x.IsDeleted);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        IQueryable<T> query = dbSet.Where(expression);

        if(includes is not null)
            foreach(string include in includes)
                query.Include(include);

        var entity = await query.FirstOrDefaultAsync(x => !x.IsDeleted); 
        return entity;
    }

    public async Task SaveAsync()
        => await appDbContext.SaveChangesAsync();
}
