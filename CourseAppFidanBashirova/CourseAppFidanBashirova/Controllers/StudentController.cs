﻿using System;
using System.Xml.Linq;
using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseAppFidanBashirova.Controllers
{
	public class StudentController
	{
		private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

		public StudentController()
		{
			_studentService = new StudentService();
            _groupService = new GroupService();
		}

		public void Create()
		{
            List<Group> groups = _groupService.GetAll();
            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("There is no group yet, add operation again");

            }
            else
            {
                ConsoleColor.Blue.WriteConsole("Add Student's FullName");
            FullName: string fullName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    ConsoleColor.Red.WriteConsole("FullName can not be null, please add name again");
                    goto FullName;
                }

                if (fullName.StringRegEx(@"\d"))
                {
                    ConsoleColor.Red.WriteConsole("FullName cannot have digits, please add FullName again");
                    goto FullName;
                }

                if (fullName.StringRegEx(@"^(?![A-Z])[^\w\s]+$"))
                {
                    ConsoleColor.Red.WriteConsole("FullName cannot have special characters, please add FullName again");
                    goto FullName;
                }

                ConsoleColor.Blue.WriteConsole("Add Student's Age");
            Age: string ageStr = Console.ReadLine();
                int age;

                bool isCorrectAge = int.TryParse(ageStr, out age);

                if (isCorrectAge)
                {

                    ConsoleColor.Blue.WriteConsole("Add Student's Address");
                Address: string address = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(address))
                    {
                        ConsoleColor.Red.WriteConsole("Address can not be null, please add address again");
                        goto Address;
                    }

                    ConsoleColor.Blue.WriteConsole("Add Student's Phone number");
                PhoneNumber: string phoneNumber = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        ConsoleColor.Red.WriteConsole("PhoneNumber can not be null, please add phoneNumber again");
                        goto PhoneNumber;
                    }

                    if (!phoneNumber.StringRegEx(@"\d"))
                    {
                        ConsoleColor.Red.WriteConsole("PhoneNumber cannot have strings, please add phoneNumber again");
                        goto PhoneNumber;
                    }

                    ConsoleColor.Blue.WriteConsole("Add Group Id");
                Id: string groupIdStr = Console.ReadLine();
                    int groupId;
                    bool isCorrectGroupId = int.TryParse(groupIdStr, out groupId);

                    if (isCorrectGroupId)
                    {
                        Group group = _groupService.GetById(groupId);

                        if (group is not null)
                        {
                            Student student = new()
                            {
                                FullName = fullName,
                                Age = age,
                                Address = address,
                                PhoneNumber = phoneNumber,
                                StudentGroup = group
                            };

                            _studentService.Create(student);
                            ConsoleColor.Green.WriteConsole("Student Created");
                            ConsoleColor.Cyan.WriteConsole("Please add operation again");

                        }
                        else
                        {
                            ConsoleColor.Red.WriteConsole("Group does not exist, please write groupId again");
                            goto Id;
                        }
                    }

                    else
                    {
                        ConsoleColor.Red.WriteConsole("Please write correct id format");
                        goto Id;
                    }

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please write correct age format");
                    goto Age;
                }
            }

         
        }

        public void GetAll()
        {
            List<Student> students = _studentService.GetAll();

            if (students is null)
            {
                ConsoleColor.Red.WriteConsole("There is no student yet, add operation again");
            }

            else
            {
                foreach (var student in students)
                {
                    string data = $"{student.Id} - {student.FullName} - {student.Age} - {student.Address} - " +
                        $"{student.PhoneNumber} - {student.StudentGroup.Name}";
                    ConsoleColor.Green.WriteConsole(data);
                }

                ConsoleColor.Cyan.WriteConsole("Please add operation again");
            }
        }

        public void GetById()
        {
            List<Student> students = _studentService.GetAll();

            if (students is null)
            {
                ConsoleColor.Red.WriteConsole("There is no student yet, add operation again");
            }
            else
            {
                ConsoleColor.Blue.WriteConsole("Add Stuedent Id");
            Id: string idStr = Console.ReadLine();
                int id;
                bool isCorrecId = int.TryParse(idStr, out id);

                if (isCorrecId)
                {
                    Student student = _studentService.GetById(id);
                    if (student is null)
                    {
                        ConsoleColor.Red.WriteConsole("Student not found, add id again");
                        goto Id;

                    }

                    string data = $"{student.Id} - {student.FullName} - {student.Age} - {student.Address}" +
                        $" - {student.PhoneNumber} - {student.StudentGroup.Name}";
                    ConsoleColor.Green.WriteConsole(data);

                    ConsoleColor.Cyan.WriteConsole("Please add operation again");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id format");
                    goto Id;
                }
            }
        }

        public void Delete()
        {
            List<Student> students = _studentService.GetAll();

            if (students is null)
            {
                ConsoleColor.Red.WriteConsole("There is no student yet, add operation again");
            }

            else
            {
                ConsoleColor.Blue.WriteConsole("Add Stuedent Id");
            Id: string idStr = Console.ReadLine();
                int id;
                bool isCorrecId = int.TryParse(idStr, out id);

                if (isCorrecId)
                {
                    Student student = _studentService.GetById(id);
                    if (student is null)
                    {
                        ConsoleColor.Red.WriteConsole("Student not found, add id again");
                        goto Id;

                    }

                    _studentService.Delete(student);
                    ConsoleColor.Green.WriteConsole("Student Deleted");

                    ConsoleColor.Cyan.WriteConsole("Please add operation again");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id format");
                    goto Id;
                }
            }
        }


        public void SearchByFullName()
        {
            List<Student> students = _studentService.GetAll();

            if (students is null)
            {
                ConsoleColor.Red.WriteConsole("There is no student yet, add operation again");
            }
            else
            {
                ConsoleColor.Blue.WriteConsole("Add SearchText");
            SearchText: string searchText = Console.ReadLine();

                if (searchText == string.Empty)
                {
                    ConsoleColor.Red.WriteConsole("You must enter something");
                    goto SearchText;
                }


                List<Student> searchedStudents = _studentService.GetAllByExpression(m => m.FullName.Trim().ToLower().Contains(searchText.Trim().ToLower()));



                if (searchedStudents is null)
                {
                    ConsoleColor.Red.WriteConsole("Data not Found,add searchText again");
                    goto SearchText;
                }

                else
                {
                    foreach (var student in searchedStudents)
                    {
                        string data = $"{student.Id} - {student.FullName} - {student.Age}" +
                            $" - {student.Address} - {student.PhoneNumber} - {student.StudentGroup.Name}";
                        ConsoleColor.Green.WriteConsole(data);
                    }

                    ConsoleColor.Cyan.WriteConsole("Please add operation again");

                }
            }
        }

	}
}

