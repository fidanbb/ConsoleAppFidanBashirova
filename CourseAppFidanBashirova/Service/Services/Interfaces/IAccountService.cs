using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IAccountService
	{
		void Register(User user);
		bool Login(string email,string password);
		List<User> GetAll();
	}
}

