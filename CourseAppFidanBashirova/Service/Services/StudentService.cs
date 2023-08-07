using System;
using System.Linq.Expressions;
using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class StudentService:IStudentService
	{
        private readonly IStudentRepository _studentRepository;
        private int _count = 1;

		public StudentService()
		{
            _studentRepository = new StudentRepository();
		}

        public void Create(Student student)
        {
            student.Id = _count;
            _studentRepository.Create(student);
            _count++;
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public void Edit(Student student)
        {
            _studentRepository.Edit(student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public List<Student> GetAllByExpression(Expression<Func<Student, bool>> expression)
        {
            return _studentRepository.GetAllByExpression(expression);
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> SortByAge()
        {
            return _studentRepository.SortByAge();
        }
    }
}

