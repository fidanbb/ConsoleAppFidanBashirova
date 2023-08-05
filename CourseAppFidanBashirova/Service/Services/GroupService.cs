using System;
using System.Linq.Expressions;
using Domain.Models;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private int _count = 1;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public void Create(Group group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;

        }

        public void Delete(Group group)
        {
            _groupRepository.Delete(group);
        }

        public void Edit(Group group)
        {
            _groupRepository.Edit(group);
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public List<Group> GetAllByExpression(Expression<Func<Group, bool>> expression)
        {
            return _groupRepository.GetAllByExpression(expression);
        }

        public Group GetById(int id)
        {
            return _groupRepository.GetById(id);
        }

        public List<Group> SortByCapacity()
        {
            return _groupRepository.SortByCapacity();
        }
    }
}

