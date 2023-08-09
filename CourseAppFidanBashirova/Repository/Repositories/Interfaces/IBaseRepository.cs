using System;
using System.Linq.Expressions;
using Domain.Common;

namespace Repository.Repositories.Interfaces
{
	public interface IBaseRepository<T> where T:BaseEntity
	{
        void Create(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetAllByExpression(Expression<Func<T, bool>> expression);
    }
}

