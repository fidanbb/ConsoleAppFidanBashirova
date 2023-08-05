using System;
using Domain.Common;

namespace Domain.Models
{
	public class Group:BaseEntity
	{
		public string Name { get; set; }
		public int Capacity { get; set; }
	}
}

