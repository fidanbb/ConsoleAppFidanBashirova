﻿using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IStudentRepository:IBaseRepository<Student>
	{
		List<Student> SortByAge();
        void Edit(Student student);

    }
}

