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

	}
}

