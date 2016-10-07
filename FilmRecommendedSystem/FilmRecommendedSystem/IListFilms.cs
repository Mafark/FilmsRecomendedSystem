using System;
using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public interface IListFilms
    {
        string Nickname { get; }
        DateTime Start { get; }
        DateTime End { get; }
        List<string> ListFilmsForPeriodOfTime();
    }
}
