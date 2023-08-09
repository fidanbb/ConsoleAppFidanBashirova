using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IGroupRepository:IBaseRepository<Group>
	{
		List<Group> SortByCapacity();
	    bool IsGroupFull(Group group);
		void Update(Group group);

    }
}

