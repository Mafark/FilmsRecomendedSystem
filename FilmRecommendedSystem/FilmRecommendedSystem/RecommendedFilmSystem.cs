using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class RecommendedFilmSystem
    {
        public void Register(IRegister register)
        {
            FIleEditor.SaveData(register.Registration());
        }

        public void AddFilm(IFilmAdder filmAdder)
        {
            FIleEditor.SaveData(filmAdder.AddFilm());
        }

        public List<string> SearchUsersWatchedSameFilms(ISearcherUsersWatchedSameFilms searcher)
        {
            return searcher.SearchUsersWatchedSameFilms();
        }

        public double AverageRating(IAverageRating rating)
        {
            return rating.GetAverageRating();
        }

        public double AverageRatingByGenre(IAverageRatingByGenre rating)
        {
            return rating.GetAverageRatingByGenre();
        }

        public List<string> ListFilmsForPeriodOfTime(IListFilms listFilms)
        {
            return listFilms.ListFilmsForPeriodOfTime();
        }
    }
}
