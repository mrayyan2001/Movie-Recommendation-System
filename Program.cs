MenuOption userChoice;
do
{
    DisplayMenu();
    userChoice = GetChoiceFromUser();
    Console.WriteLine(new string('-', 50));
    HandleMenuOption(userChoice);
    Console.WriteLine(new string('-', 50));

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
            DisplayMovies(TopRatedMovie(ReadInteger("How Many Movies? ")));
            break;
        case MenuOption.GenerateRandomRecommendation:
            Console.WriteLine(GenerateRandomMovieRecommendation());
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

int ReadInteger(string promptMessage)
{
    Console.Write(promptMessage);
    int userInput;
    try
    {
        userInput = Convert.ToInt32(Console.ReadLine());
        return userInput;
    }
    catch
    {
        DisplayErrorMessage("Invalid Input");
        return ReadInteger(promptMessage);
    }
}

Movie GenerateRandomMovieRecommendation()
{
    Random random = new Random();
    List<Movie> movies = ImportMovies("./movies.txt");
    return movies.ElementAt(random.Next(0, movies.Count));
}

List<Movie> ImportMovies(string filePath)
{
    return File.ReadAllLines("./movies.txt").Select(
        x => Movie.MovieFromString(x)).ToList();
}

List<Movie> TopRatedMovie(int size = 10)
{
    return ImportMovies("./movies.txt").OrderByDescending(x => x.Rating).Take(size).ToList();
}

void DisplayMovies(List<Movie> movies)
{
    Console.WriteLine($"{"ID",3} {"Title",-50} {"Genre",-10} {"Rating",4}");
    movies.ForEach(x => Console.WriteLine(x));
}

void DisplayAllMovies()
{
    List<Movie> movies = ImportMovies("./movies.txt").OrderByDescending(x => x.Rating).ToList();
    DisplayMovies(movies);
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