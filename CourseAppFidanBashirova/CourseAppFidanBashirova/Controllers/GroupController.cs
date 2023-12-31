﻿using System;
using System.Xml.Linq;
using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseAppFidanBashirova.Controllers
{
	public class GroupController
	{
		private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;


        public GroupController()
		{
			_groupService = new GroupService();
            _studentService = new StudentService();
		}

		public void Create()
		{
			ConsoleColor.Blue.WriteConsole("Add Group Name");
			GroupName:  string groupName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupName))
            {
                ConsoleColor.Red.WriteConsole("Group Name can not be null, please add Group Name again");
                goto GroupName;
            }

            if (groupName.StringRegEx(@"^(?![A-Z])[^\w\s]+$"))
            {
                ConsoleColor.Red.WriteConsole("Group Name cannot have special characters, please add group name again");
                goto GroupName;
            }

            List<Group> groups = _groupService.GetAll();

            if (groups is not null)
            {
                foreach (var group in groups)
                {
                    if (group.Name.Trim().ToLower() == groupName.Trim().ToLower())
                    {
                        ConsoleColor.Red.WriteConsole("This GroupName already exists, add group name again");
                        goto GroupName;
                    }
                }
            }

            ConsoleColor.Blue.WriteConsole("Add Group Capacity");
            Capacity: string capacityStr = Console.ReadLine();

			int capacity;

			bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);


            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                ConsoleColor.Red.WriteConsole("Capacity can not be null, please add capacity again");
                goto Capacity;
            }


            if (isCorrectCapacity)
			{

                if (capacity>1 && capacity<10)
                {
                    Group group = new()
                    {
                        Name = groupName,
                        Capacity = capacity
                    };
                    _groupService.Create(group);
                    ConsoleColor.Green.WriteConsole("Group Created");
                    ConsoleColor.Cyan.WriteConsole("Please add operation again");
                }

                else
                {
                    ConsoleColor.Red.WriteConsole("Capacity must be between 1 and 10, please add capacity again");
                    goto Capacity;
                }
				
            }

			else
			{
                ConsoleColor.Red.WriteConsole("Please add correct capacity format");
				goto Capacity;
            }



        }

		public void GetAll()
		{
            List<Group> groups = _groupService.GetAll();

            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("There is no group yet, add operation again");
            }

            else
            {
                foreach (var group in groups)
                {
                    string data = $"{group.Id} - {group.Name} - {group.Capacity}";
                    ConsoleColor.Green.WriteConsole(data);
                   
                }
                ConsoleColor.Cyan.WriteConsole("Please add operation again");
            }

        }


		public void GetById()
		{

            List<Group> groups = _groupService.GetAll();

            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("There is no group yet, add operation again");
            }

            else
            {
                ConsoleColor.Blue.WriteConsole("Add Group Id");
            Id: string idStr = Console.ReadLine();

                int id;

                bool IsCorrectId = int.TryParse(idStr, out id);


                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleColor.Red.WriteConsole("Id can not be null, please add Id again");
                    goto Id;
                }



                if (IsCorrectId)
                {
                    var group = _groupService.GetById(id);

                    if (group is null)
                    {

                        ConsoleColor.Red.WriteConsole("Data not found,Write id again");
                        goto Id;
                    }

                    string data = $"{group.Id} - {group.Name} - {group.Capacity}";
                    ConsoleColor.Green.WriteConsole(data);

                    ConsoleColor.Cyan.WriteConsole("Please add operation again");

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add id format again");
                    goto Id;
                }
            }

        }

        public void Delete()
        {

            List<Group> groups = _groupService.GetAll();

            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("There is no group yet, add operation again");
            }
            else
            {
                ConsoleColor.Blue.WriteConsole("Add Group Id");
            Id: string idStr = Console.ReadLine();

                int id;

                bool IsCorrectId = int.TryParse(idStr, out id);

                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleColor.Red.WriteConsole("Id can not be null, please add Id again");
                    goto Id;
                }

                if (IsCorrectId)
                {
                    Group group = _groupService.GetById(id);

                    if (group is null)
                    {

                        ConsoleColor.Red.WriteConsole("Group not found,Write id again");
                        goto Id;
                    }

                    if (group.Students.Count > 0)
                    {
                        ConsoleColor.Red.WriteConsole("This group has students,you cannot delete it, add operation again");
                    }

                    else
                    {
                        _groupService.Delete(group);
                        ConsoleColor.Green.WriteConsole("Group Deleted");
                        ConsoleColor.Cyan.WriteConsole("Please add operation again");
                    }

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add id format again");
                    goto Id;
                }
            }
            
        }


        public void SearchByName()
        {
            List<Group> groups = _groupService.GetAll();

            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("There is no group yet, add operation again");
            }
            else
            {
                ConsoleColor.Cyan.WriteConsole("Add SearchText");
            SearchText: string searchText = Console.ReadLine();

                if (searchText == string.Empty)
                {
                    ConsoleColor.Red.WriteConsole("You must enter something");
                    goto SearchText;
                }


                List<Group> searchedGroups = _groupService.GetAllByExpression(m => m.Name.Trim().ToLower().Contains(searchText.Trim().ToLower()));



                if (searchedGroups is null)
                {
                    ConsoleColor.Red.WriteConsole("Data not found,add searchText again");
                    goto SearchText;
                }

                else
                {
                    foreach (var group in searchedGroups)
                    {
                        string data = $"{group.Id} - {group.Name} - {group.Capacity}";
                        ConsoleColor.Green.WriteConsole(data);
                    }

                    ConsoleColor.Cyan.WriteConsole("Please add operation again");

                }
            }
            
        }

        public void SortByCapacity()
        {
            List<Group> groups = _groupService.SortByCapacity();


            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("There is no group yet, Add operation again");
            }

            else
            {
                foreach (var group in groups)
                {
                    string data = $"{group.Id} - {group.Name} - {group.Capacity}";
                    ConsoleColor.Green.WriteConsole(data);
                }

                ConsoleColor.Cyan.WriteConsole("Please add operation again");
            }

        }

        public void Edit()
        {
            List<Group> groups = _groupService.GetAll();

            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("There is no group yet, Add operation again");
            }

            else
            {
                ConsoleColor.Blue.WriteConsole("Add Group Id");
            Id: string idStr = Console.ReadLine();

                int id;

                bool IsCorrectId = int.TryParse(idStr, out id);


                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleColor.Red.WriteConsole("Id can not be null, please add Id again");
                    goto Id;
                }



                if (IsCorrectId)
                {
                    Group group = _groupService.GetById(id);

                    if (group is null)
                    {
                        ConsoleColor.Red.WriteConsole("Group not found,Write id again");
                        goto Id;
                    }

                    else
                    {

                        ConsoleColor.Blue.WriteConsole("Edit Group Name");
                    Name: string name = Console.ReadLine();

                        foreach (var item in groups)
                        {
                            if (item.Name.Trim().ToLower() == name.Trim().ToLower())
                            {
                                ConsoleColor.Red.WriteConsole("This Group Name has already taken, edit name again");
                                goto Name;
                            }
                        }

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            name = group.Name;
                        }

                        if (name.StringRegEx(@"^(?![A-Z])[^\w\s]+$"))
                        {
                            ConsoleColor.Red.WriteConsole("Group Name cannot have special characters, please add group name again");
                            goto Name;
                        }

                       

                        ConsoleColor.Blue.WriteConsole("Edit Capacity");
                    Capacity: string capacityStr = Console.ReadLine();

                        int capacity;

                        bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);

                        if (string.IsNullOrWhiteSpace(capacityStr))
                        {
                            capacity = group.Capacity;
                            Group newGroup = new()
                            {
                                Id = id,
                                Name = name,
                                Capacity = capacity
                            };
                            _groupService.Edit(newGroup);
                            ConsoleColor.Green.WriteConsole("Group Edited");
                        }
                        else
                        {
                            if (isCorrectCapacity)
                            {
                                if (capacity <= 1 || capacity >= 10)
                                {

                                    ConsoleColor.Red.WriteConsole("Capacity must be between 1 and 10,add capacity again");
                                    goto Capacity;

                                    
                                }
                                if (group.Students.Count() > capacity)
                                {
                                    ConsoleColor.Red.WriteConsole("Capacity you edited is less than student number," +
                                        $"capacity must greater than {group.Students.Count}, add capacity again");
                                    goto Capacity;
                                }

                                var students = _studentService.GetAll();

                                Group newGroup = new()
                                {
                                    Id = id,
                                    Name = name,
                                    Capacity = capacity,
                                    
                                };
                                
                                if (students != null)
                                {
                                    newGroup.Students = students.Where(student => student.StudentGroup.Id == id).ToList();
                                }
                                else
                                {
                                 
                                    newGroup.Students = new List<Student>(); 
                                }
                                _groupService.Edit(newGroup);

                            }
                            else
                            {
                                ConsoleColor.Red.WriteConsole("Please add capacity format again");
                                goto Capacity;
                            }

                            ConsoleColor.Green.WriteConsole("Group Edited");
                            ConsoleColor.Cyan.WriteConsole("Please add operation again");

                        }
                    }

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add id format again");
                    goto Id;
                }
            }
        }

    }
}

