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


            if (!name.StringRegEx(@"^[A-Za-z.'\- ]+$"))
            {
                ConsoleColor.Red.WriteConsole("Name cannot have digits and special chars, please add name again");
                goto Name;
            }


            ConsoleColor.Blue.WriteConsole("Add Surname");
        Surname: string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Surname can not be null, please add surname again");
                goto Surname;
            }


            if (!surname.StringRegEx(@"^[A-Za-z.'\- ]+$"))
            {
                ConsoleColor.Red.WriteConsole("Name cannot have digits and special chars, please add surname again");
                goto Surname;
            }

            ConsoleColor.Blue.WriteConsole("Add Age");

            Age: string ageStr = Console.ReadLine();
            int age;

            bool isCorrectAge = int.TryParse(ageStr, out age);

            if (!isCorrectAge)
            {
                ConsoleColor.Red.WriteConsole("Please add age format again");
                goto Age;
            }


            ConsoleColor.Blue.WriteConsole("Add Email");

            Email: string email = Console.ReadLine();

            if (!email.StringRegEx(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ConsoleColor.Red.WriteConsole("Please add correct email format again");
                goto Email;
            }

            ConsoleColor.Blue.WriteConsole("Add Password");

        Password: string password = Console.ReadLine();

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


        public void Login()
        {
            var users = _accountService.GetAll();

            if (!users.Any())
            {
                ConsoleColor.Red.WriteConsole("You must register first");
                Register();

            }
            else
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
}

