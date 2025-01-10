struct Movie
{
    int ID { get; set; }
    string Title { get; set; }
    string Genre { get; set; }
    float Rating { get; set; }

    public override string ToString()
    {
        return $"{ID} {Title} {Genre} {Rating}";
    }

    public static Movie MovieFromString(string str)
    {
        List<string> attr = str.Split(',').ToList();
        Movie movie = new Movie();
        movie.ID = Convert.ToInt32(attr[0]);
        movie.Title = attr[1];
        movie.Genre = attr[2];
        movie.Rating = Convert.ToSingle(attr[3]);
        return movie;
    }

}