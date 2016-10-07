namespace FilmRecommendedSystem
{
    public interface IAverageRatingByGenre
    {
        string Nickname { get; }
        string Genre { get; }
        double GetAverageRatingByGenre();
    }
}
