using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public interface IFilmAdder
    {
        string Nickname { get; }
        string FilmTitle { get; }
        string Genre { get; }
        string Rating { get; }
        List<User> AddFilm();
    }
}
