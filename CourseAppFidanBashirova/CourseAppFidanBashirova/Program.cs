
using System;
using CourseAppFidanBashirova.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

AccountController accountController = new AccountController();
GroupController groupController = new GroupController();
StudentController studentController = new StudentController();

AccountMenu();




while (true)
{
AccountOperation: string accountOperationStr = Console.ReadLine();

    int accountOperation;

    bool isCorrectAccountOperation = int.TryParse(accountOperationStr, out accountOperation);

    if (isCorrectAccountOperation)
    {
        if (accountOperation == (int)AccountOperations.Login)
        {

            if (accountController.CheckAnyUsersExit())
            {
                ConsoleColor.Red.WriteConsole("You must register first");
                accountController.Register();
                AccountMenu();

            }

            else
            {
                accountController.Login();
                Menu();
            Operation: string operationStr = Console.ReadLine();

                int operation;

                bool isCorrectOperation = int.TryParse(operationStr, out operation);

                switch (operation)
                {
                    case (int)Operations.CreateGroup:
                        groupController.Create();
                        goto Operation;
                    case (int)Operations.DeleteGroup:
                        groupController.Delete();
                        goto Operation;
                    case (int)Operations.EditGroup:
                        groupController.Edit();
                        goto Operation;
                    case (int)Operations.GetAllGroups:
                        groupController.GetAll();
                        goto Operation;
                    case (int)Operations.GetGroupById:
                        groupController.GetById();
                        goto Operation;
                    case (int)Operations.SearchGroupByName:
                        groupController.SearchByName();
                        goto Operation;
                    case (int)Operations.SortGroupByCapacity:
                        groupController.SortByCapacity();
                        goto Operation;
                    case (int)Operations.CreateStudent:
                        studentController.Create();
                        goto Operation;
                    case (int)Operations.DeleteStudent:
                        Console.WriteLine("delete");
                        goto Operation;
                    case (int)Operations.EditStudent:
                        Console.WriteLine("edit");
                        goto Operation;
                    case (int)Operations.GetAllStudents:
                        studentController.GetAll();
                        goto Operation;
                    case (int)Operations.GetStudentById:
                        studentController.GetById();
                        goto Operation;
                    case (int)Operations.SearchStudentByFullName:
                        Console.WriteLine("search");
                        goto Operation;
                    case (int)Operations.SortStudentByAge:
                        Console.WriteLine("sort");
                        goto Operation;
                    default:
                        ConsoleColor.Red.WriteConsole("Please write correct option");
                        goto Operation;
                }

            }

        }
        else if (accountOperation == (int)AccountOperations.Register)
        {
            accountController.Register();
            AccountMenu();
        }



        else
        {
            ConsoleColor.Red.WriteConsole("Please write correct option");
            goto AccountOperation;
        }
    }

    else
    {
        ConsoleColor.Red.WriteConsole("Please write correct option format");
        goto AccountOperation;
    }
}





static void AccountMenu()
{
    ConsoleColor.Cyan.WriteConsole("Choose one option: " +
    "1 - Login 2 - Register");
}

static void Menu()
{
    ConsoleColor.Cyan.WriteConsole("Welcome to our application." +
        "Please select one option: " +
    "GroupOperations: 1 - CreateGroup, 2 - DeleteGroup, 3 - EditGroup, 4 - GetAllGroups, " +
    "5 - GetGroupById, 6 - SearchGroupByName, 7 - SortGroupByCapacity, " +
    "StudentOperations: 8 - CreateStudent, " +
    "9 - DeleteStudent, 10 - EditStudent, 11 - GetAllStudents, 12 - GetStudentById, " +
    "13 - SearchStudentByFullName, 14 - SortStudentByAge");
}