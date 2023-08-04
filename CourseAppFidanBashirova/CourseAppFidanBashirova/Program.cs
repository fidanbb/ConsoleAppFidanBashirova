
using CourseAppFidanBashirova.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

AccountController accountController = new AccountController();

AccountMenu();

while (true)
{
AccountOperation: string accountOperationStr = Console.ReadLine();

    int accountOperation;

    bool isCorrectAccountOperation = int.TryParse(accountOperationStr, out accountOperation);

    if (isCorrectAccountOperation)
    {
        switch (accountOperation)
        {
            case (int)AccountOperations.Register:
                accountController.Register();
                break;
            case (int)AccountOperations.Login:
                accountController.Login();
                break;
            default:
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
    "1 - Register 2 - Login");
}