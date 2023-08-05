using System;
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
    }
}

