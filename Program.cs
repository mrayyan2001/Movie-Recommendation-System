MenuOption userChoice;
do
{
    DisplayMenu();
    userChoice = GetChoiceFromUser();
    Console.WriteLine(new string('-', 50));
    HandleMenuOption(userChoice);

} while (userChoice != MenuOption.Exit);

void HandleMenuOption(MenuOption menuOption)
{
    switch (userChoice)
    {
        case MenuOption.DisplayAllMovies:
            DisplayAllMovies();
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
}

void DisplayAllMovies()
{
    List<Movie> movies = File.ReadAllLines("./movies.txt").Select(
        x => Movie.MovieFromString(x)).OrderByDescending(x => x.Rating).ToList();
    movies.ForEach(x => Console.WriteLine(x));
}

void DisplayMenu()
{
    Console.WriteLine("1. Display all movies sorted by rating in descending order.");
    Console.WriteLine("2. Search movies by genre.");
    Console.WriteLine("3. Find the top-rated movie using LINQ.");
    Console.WriteLine("4. Generate a random movie recommendation.");
    Console.WriteLine("5. Add a new movie with user input and save it to the file.");
    Console.WriteLine("6. Exit the program.");
}

void DisplayErrorMessage(string errorMessage)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("[error] ");
    Console.ResetColor();
    Console.WriteLine(errorMessage);
}

MenuOption GetChoiceFromUser()
{
    MenuOption userChoice;
    Console.Write("Enter your choice: ");
    if (Enum.TryParse(Console.ReadLine(), out userChoice))
    {
        if (Enum.IsDefined(typeof(MenuOption), userChoice))
            return userChoice;
    }
    Console.Clear();
    DisplayErrorMessage("Invalid Input, Please Try Again...");
    DisplayMenu();
    return GetChoiceFromUser();
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