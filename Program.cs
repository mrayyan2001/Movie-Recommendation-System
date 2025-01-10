string? userChoice;
do
{
    Console.WriteLine("1. Display all movies sorted by rating in descending order.");
    Console.WriteLine("2. Search movies by genre.");
    Console.WriteLine("3. Find the top-rated movie using LINQ.");
    Console.WriteLine("4. Generate a random movie recommendation.");
    Console.WriteLine("5. Add a new movie with user input and save it to the file.");
    Console.WriteLine("6. Exit the program.");
    Console.Write("Enter Your Choice: ");
    userChoice = Console.ReadLine();
    Console.Clear();
    switch (userChoice)
    {
        case "1":
            break;
        case "2":
            break;
        case "3":
            break;
        case "4":
            break;
        case "5":
            break;
        case "6":
            break;
        default:
            DisplayErrorMessage("Invalid Input, Please Try Again...");
            break;
    }
} while (userChoice != "6");


void DisplayErrorMessage(string errorMessage)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("[error] ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(errorMessage);
}