﻿using System;
using System.Linq.Expressions;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> SortByCapacity()
        {
            List<Group> sortedData = AppDbContext<Group>.datas.OrderByDescending(m => m.Capacity).ToList(); ;


            if (!sortedData.Any())
            {
                return null;
            }

            return sortedData;
        }

        public bool IsGroupFull(Group group)
        {
            return group.Students.Count >= group.Capacity;
        }

        public void Update(Group group)
        {
            Group exsistingGroup = AppDbContext<Group>.datas.FirstOrDefault(m => m.Id == group.Id);
            exsistingGroup.Name = group.Name;
            exsistingGroup.Capacity = group.Capacity;
        }
    }
}

