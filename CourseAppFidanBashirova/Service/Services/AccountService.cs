using System;
using Domain.Models;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private int _count;
        private List<User> users = new List<User>();

        public void Register(User user)
        {
            user.Id = _count;
            users.Add(user);
            _count++;
        }

        public bool Login(string email,string password)
        {
            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public List<User> GetAll()
        {
            return users;
        }
    }
}

