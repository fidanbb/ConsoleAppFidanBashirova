﻿using System;
using Domain.Models;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class StudentRepository:BaseRepository<Student>,IStudentRepository
	{
		
	}
}

