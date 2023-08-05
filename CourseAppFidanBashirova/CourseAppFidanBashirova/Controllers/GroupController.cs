using System;
using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseAppFidanBashirova.Controllers
{
	public class GroupController
	{
		private readonly IGroupService _groupService;

		public GroupController()
		{
			_groupService = new GroupService();
		}

		public void Create()
		{
			ConsoleColor.Blue.WriteConsole("Add Group Name");
			Name:  string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Name can not be null, please add name again");
                goto Name;
            }

            List<Group> groups = _groupService.GetAll();

            foreach (var group in groups)
            {
                if (group.Name == name)
                {
                    ConsoleColor.Red.WriteConsole("This name already exists, add group name again");
                    goto Name;
                }
            }

            ConsoleColor.Blue.WriteConsole("Add Group Capacity");
            Capacity: string capacityStr = Console.ReadLine();

			int capacity;

			bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);

			if (isCorrectCapacity)
			{
				Group group = new()
				{
					Name = name,
					Capacity = capacity
				};
				_groupService.Create(group);
            }

			else
			{
                ConsoleColor.Red.WriteConsole("Please add correct capacity format");
				goto Capacity;
            }



        }

		public void GetAll()
		{
            var groups = _groupService.GetAll();

            foreach (var group in groups)
            {
                string data = $"{group.Id} - {group.Name} - {group.Capacity}";
                ConsoleColor.Green.WriteConsole(data);
            }
        }


		public void GetById()
		{
            ConsoleColor.Cyan.WriteConsole("Group Id");
        Id: string idStr = Console.ReadLine();

            int id;

            bool IsCorrectId = int.TryParse(idStr, out id);

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
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add id format again");
                goto Id;
            }
        }

        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Group Id");
        Id: string idStr = Console.ReadLine();

            int id;

            bool IsCorrectId = int.TryParse(idStr, out id);

            if (IsCorrectId)
            {
                Group group = _groupService.GetById(id);

                if (group is null)
                {

                    ConsoleColor.Red.WriteConsole("Data not found,Write id again");
                    goto Id;
                }

                _groupService.Delete(group);
                ConsoleColor.Green.WriteConsole("Group Deleted");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add id format again");
                goto Id;
            }
        }


        public void SearchByName()
        {
            ConsoleColor.Cyan.WriteConsole("Add SearchText");
        SearchText: string searchText = Console.ReadLine();

            if (searchText == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("You must enter something");
                goto SearchText;
            }


            List<Group> groups = _groupService.GetAllByExpression(m => m.Name.Trim().ToLower().Contains(searchText.Trim().ToLower()));



            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("Data not Found,add searchText again");
                goto SearchText;
            }

            else
            {
                foreach (var group in groups)
                {
                    string data = $"{group.Id} - {group.Name} - {group.Capacity}";
                    ConsoleColor.Green.WriteConsole(data);
                }

            }
        }

        public void SortByCapacity()
        {
            List<Group> groups = _groupService.SortByCapacity();


            if (groups is null)
            {
                ConsoleColor.Red.WriteConsole("There is no group, Add operation again");
            }

            else
            {
                foreach (var group in groups)
                {
                    string data = $"{group.Id} - {group.Name} - {group.Capacity}";
                    ConsoleColor.Green.WriteConsole(data);
                }

            }

        }

    }
}

