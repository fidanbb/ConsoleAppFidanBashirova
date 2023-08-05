using System;
using System.Linq.Expressions;
using Domain.Common;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class BaseRepository<T> :IBaseRepository<T> where T:BaseEntity
	{

        public void Create(T entity)
        {
            AppDbContext<T>.datas.Add(entity);
        }

        public void Delete(T entity)
        {
            AppDbContext<T>.datas.Remove(entity);
        }

        public void Edit(T entity)
        {
           T updatedData = AppDbContext<T>.datas.FirstOrDefault(m => m.Id == entity.Id);
        }

        public List<T> GetAll()
        {
            return AppDbContext<T>.datas;
        }

        public List<T> GetAllByExpression(Expression<Func<T, bool>> expression)
        {
            List<T> filteredData = AppDbContext<T>.datas.Where(expression.Compile()).ToList();


            if (!filteredData.Any())
            {
                return null;
            }

            return filteredData;
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.datas.FirstOrDefault(m => m.Id == id);
        }
    }
}

