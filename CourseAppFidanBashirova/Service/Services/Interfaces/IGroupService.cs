using System;
using System.Linq.Expressions;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IGroupService
	{
        void Create(Group group);
        void Delete(Group group);
        void Edit(Group group);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> GetAllByExpression(Expression<Func<Group, bool>> expression);
        List<Group> SortByCapacity();
    }
}

