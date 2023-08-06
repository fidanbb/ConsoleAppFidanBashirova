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
           T data = AppDbContext<T>.datas.FirstOrDefault(m => m.Id == entity.Id);
            AppDbContext<T>.datas.Remove(data);
            AppDbContext<T>.datas.Add(entity);
        }

        public List<T> GetAll()
        {
            List<T> datas = AppDbContext<T>.datas;

            if (!datas.Any())
            {
                return null;
            }

            return datas;
        }

        public List<T> GetAllByExpression(Expression<Func<T, bool>> expression)
        {
            List<T> searchedData = AppDbContext<T>.datas.Where(expression.Compile()).ToList();


            if (!searchedData.Any())
            {
                return null;
            }

            return searchedData;
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.datas.FirstOrDefault(m => m.Id == id);
        }
    }
}

