using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public interface ISearcherUsersWatchedSameFilms
    {
        string Nickname { get; }
        List<string> SearchUsersWatchedSameFilms();
    }
}
