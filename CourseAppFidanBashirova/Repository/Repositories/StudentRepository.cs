using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class StudentRepository:BaseRepository<Student>,IStudentRepository
	{
        public List<Student> SortByAge()
        {
            List<Student> sortedData = AppDbContext<Student>.datas.OrderByDescending(m => m.Age).ToList(); ;


            if (!sortedData.Any())
            {
                return null;
            }

            return sortedData;
        }
    }
}

