public struct Movie
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public float Rating { get; set; }

    public override string ToString()
    {
        return $"{ID,3} {Title,-50} {Genre,-10} {Rating,4}";
    }

    public static bool CheckRating(float rating)
    {
        if (rating > 5 || rating < 0)
            return false;
        return true;
    }

    public static Movie MovieFromString(string str)
    {
        List<string> attr = str.Split(',').ToList();
        if (attr.Count != 4)
            throw new FormatException("Wrong movie format.");
        Movie movie = new Movie();
        movie.ID = Convert.ToInt32(attr[0]);
        movie.Title = attr[1];
        movie.Genre = attr[2];
        movie.Rating = Convert.ToSingle(attr[3]);
        return movie;
    }

}