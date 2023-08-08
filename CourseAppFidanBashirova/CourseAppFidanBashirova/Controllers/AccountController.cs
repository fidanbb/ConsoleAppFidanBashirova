using System;
using System.Text.RegularExpressions;
using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseAppFidanBashirova.Controllers
{
	public class AccountController
	{
		private readonly IAccountService _accountService;

		public AccountController()
		{
			_accountService = new AccountService();
		}


        public void Register()
		{
			ConsoleColor.Blue.WriteConsole("Add Name");
		Name: string name = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(name))
			{
				ConsoleColor.Red.WriteConsole("Name can not be null, please add name again");
				goto Name;
			}


            if (name.StringRegEx(@"\d"))
            {
                ConsoleColor.Red.WriteConsole("Name cannot have digits, please add name again");
                goto Name;
            }

            if (name.StringRegEx(@"^(?![A-Z])[^\w\s]+$"))
            {
                ConsoleColor.Red.WriteConsole("Name cannot have special characters, please add name again");
                goto Name;
            }

            ConsoleColor.Blue.WriteConsole("Add Surname");
        Surname: string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Surname can not be null, please add surname again");
                goto Surname;
            }



            if (surname.StringRegEx(@"\d"))
            {
                ConsoleColor.Red.WriteConsole("Surname cannot have digits, please add surname again");
                goto Surname;
            }

            if (surname.StringRegEx(@"^(?![A-Z])[^\w\s]+$"))
            {
                ConsoleColor.Red.WriteConsole("Surname cannot have special characters, please add surname again");
                goto Surname;
            }

            ConsoleColor.Blue.WriteConsole("Add Age");

            Age: string ageStr = Console.ReadLine();
            int age;

            bool isCorrectAge = int.TryParse(ageStr, out age);

            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Age can not be null, please add age again");
                goto Age;
            }

            if (!isCorrectAge)
            {
                ConsoleColor.Red.WriteConsole("Please add age format again");
                goto Age;
            }


            ConsoleColor.Blue.WriteConsole("Add Email");

            Email: string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Email can not be null, please add email again");
                goto Email;
            }

            if (!email.StringRegEx(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ConsoleColor.Red.WriteConsole("Please add correct email format again");
                goto Email;
            }

            ConsoleColor.Blue.WriteConsole("Add Password");

        Password: string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole("Password can not be null, please add password again");
                goto Password;
            }


            if (!password.StringRegEx(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$"))
            {
                ConsoleColor.Red.WriteConsole("Password must have at least one uppercase " +
                    "letter,one number and minimum 8 characters," +
                    "Please add correct password format");
                goto Password;
            }

            ConsoleColor.Blue.WriteConsole("Add Confirm Password");

        ConfirmPassword: string confirmPassword = Console.ReadLine();

            if (confirmPassword == password)
            {
                User user = new()
                {
                    Name = name,
                    Surname = surname,
                    Age = age,
                    Email = email,
                    Password = password
                };

                _accountService.Register(user);
                ConsoleColor.Green.WriteConsole("Succesfully Registered");
            }

            else
            {
                ConsoleColor.Red.WriteConsole("Password and Confirm password is not same, add confirm password again");
                goto ConfirmPassword;
            }

        }


        public bool CheckAnyUsersExit()
        {
            var users = _accountService.GetAll();

            return !users.Any();
        }


        public void Login()
        {
            
                ConsoleColor.Blue.WriteConsole("Add Email");
            Email: string email = Console.ReadLine();

                if (!email.StringRegEx(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    ConsoleColor.Red.WriteConsole("Please add correct email format again");
                    goto Email;
                }

                ConsoleColor.Blue.WriteConsole("Add Password");

                string password = Console.ReadLine();


                bool isLogin = _accountService.Login(email, password);


                if (isLogin)
                {
                    ConsoleColor.Green.WriteConsole("Login Succesfull");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Email or password is wrong, please add again");
                    goto Email;

                }

            

        }


	}
}

