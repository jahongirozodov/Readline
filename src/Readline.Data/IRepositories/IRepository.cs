﻿using Readline.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Readline.Data.IRepositories;

public interface IRepository<T> where T: Auditable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Destroy(T entity);
    Task<T> GetAsync(Expression<Func<T,bool>> expression, string[] includes = null);
    IQueryable<T> GetAll(Expression<Func<T,bool>> expression = null, bool IsNoTracked = true, string[] includes = null);
    Task SaveAsync();
}
