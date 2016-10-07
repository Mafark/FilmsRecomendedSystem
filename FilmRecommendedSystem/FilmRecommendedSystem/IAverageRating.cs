namespace FilmRecommendedSystem
{
    public interface IAverageRating
    {
        string Nickname { get; }
        double GetAverageRating();
    }
}
