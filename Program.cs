﻿MenuOption userChoice;
do
{
    Console.WriteLine("1. Display all movies sorted by rating in descending order.");
    Console.WriteLine("2. Search movies by genre.");
    Console.WriteLine("3. Find the top-rated movie using LINQ.");
    Console.WriteLine("4. Generate a random movie recommendation.");
    Console.WriteLine("5. Add a new movie with user input and save it to the file.");
    Console.WriteLine("6. Exit the program.");
    Console.Write("Enter Your Choice: ");
    userChoice = GetChoiceFromUser();
    Console.Clear();
    switch (userChoice)
    {
        case MenuOption.DisplayAllMovies:
            break;
        case MenuOption.SearchMoviesByGenre:
            break;
        case MenuOption.FindTopRatedMovie:
            break;
        case MenuOption.GenerateRandomRecommendation:
            break;
        case MenuOption.AddNewMovie:
            break;
        case MenuOption.Exit:
            break;
        default:
            DisplayErrorMessage("Invalid Input, Please Try Again...");
            break;
    }
} while (userChoice != MenuOption.Exit);


void DisplayErrorMessage(string errorMessage)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("[error] ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(errorMessage);
}

MenuOption GetChoiceFromUser()
{
    MenuOption userChoice;
    Console.Write("Enter your choice: ");
    if (Enum.TryParse(Console.ReadLine(), out userChoice))
    {
        return userChoice;
    }
    else
    {
        DisplayErrorMessage("Invalid Input, Please Try Again...");
        return GetChoiceFromUser();
    }
}

enum MenuOption
{
    DisplayAllMovies = 1,
    SearchMoviesByGenre,
    FindTopRatedMovie,
    GenerateRandomRecommendation,
    AddNewMovie,
    Exit
}