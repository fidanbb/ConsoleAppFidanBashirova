
using CourseAppFidanBashirova.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

AccountController accountController = new AccountController();
GroupController groupController = new GroupController();

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
                        Console.WriteLine("Edit");
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













//while (true)
//{
//AccountOperation: string accountOperationStr = Console.ReadLine();

//    int accountOperation;

//    bool isCorrectAccountOperation = int.TryParse(accountOperationStr, out accountOperation);

//    if (isCorrectAccountOperation)
//    {
//        switch (accountOperation)
//        { 
//            case (int)AccountOperations.Login:
//                if (accountController.CheckAnyUsersExit())
//                {
//                    ConsoleColor.Red.WriteConsole("You must register first");
//                    accountController.Register();
//                    AccountMenu();

//                }
//                else
//                {
//                    accountController.Login();
//                    Menu();
//                Operation: string operationStr = Console.ReadLine();

//                    int operation;

//                    bool isCorrectOperation = int.TryParse(operationStr, out operation);

//                    switch (operation)
//                    {
//                        case (int)Operations.CreateGroup:
//                            groupController.Create();
//                            break;
//                        case (int)Operations.DeleteGroup:
//                            Console.WriteLine("delete");
//                            break;
//                        case (int)Operations.EditGroup:
//                            Console.WriteLine("Edit");
//                            break;
//                        case (int)Operations.GetAllGroups:
//                            groupController.GetAll();
//                            break;
//                        case (int)Operations.GetGroupById:
//                            Console.WriteLine("GetById");
//                            break;
//                        default:
//                            ConsoleColor.Red.WriteConsole("Please write correct option");
//                            goto Operation;
//                    }
//                }
//                break;
//            case (int)AccountOperations.Register:
//                accountController.Register();
//                AccountMenu();
//                break;
//            default:
//                ConsoleColor.Red.WriteConsole("Please write correct option");
//                goto AccountOperation;
//        }
//    }

//    else
//    {
//        ConsoleColor.Red.WriteConsole("Please write correct option format");
//        goto AccountOperation;
//    }
//}

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
    "5 - GetAllGroups, 6 - SearchGroupByName, 7 - SortGroupByCapacity");
}