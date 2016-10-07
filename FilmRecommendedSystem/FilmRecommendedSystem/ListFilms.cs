using System;
using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class ListFilms : IListFilms
    {
        List<User> users = new List<User>();
        public string Nickname { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public ListFilms(string nickname, DateTime start, DateTime end)
        {
            users = FIleEditor.LoadData();
            Nickname = nickname;
            Start = start;
            End = end;
        }

        public ListFilms(List<User> users, string nickname, DateTime start, DateTime end)
        {
            this.users = users;
            Nickname = nickname;
            Start = start;
            End = end;
        }

        public List<string> ListFilmsForPeriodOfTime()
        {
            User user = Searcher.SearchUser(Nickname, users);
            List<string> FilmsNames = new List<string>();
            for (int i = 0; i < user.Films.Count; i++)
            {
                DateTime TimeOfWatchedFilm = Convert.ToDateTime(user.Films[i][3]);
                if (TimeOfWatchedFilm >= Start && TimeOfWatchedFilm <= End)
                {
                    FilmsNames.Add(user.Films[i][0]);
                }
            }
            return FilmsNames;
        }
    }
}
