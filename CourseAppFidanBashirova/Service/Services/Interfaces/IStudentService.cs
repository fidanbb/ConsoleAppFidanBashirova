using System;
using System.Linq.Expressions;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IStudentService
	{
        void Create(Student student);
        void Delete(Student student);
        void Edit(Student student);
        Student GetById(int id);
        List<Student> GetAll();
        List<Student> GetAllByExpression(Expression<Func<Group, bool>> expression);
    }
}

