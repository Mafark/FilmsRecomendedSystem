using System;
using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class RecommendedFilmSystem
    {
        private List<User> users = new List<User>();
        public RecommendedFilmSystem()
        {
            users = FIleEditor.LoadData();
        }

        public void Register(string nickname, string email, string name, string surname)
        {

            users.Add(new User(nickname, name, surname, email));
            FIleEditor.SaveData(users);
        }

        public void AddFilm(string name, string genre, string rating)
        {
            List<string> film = new List<string>();
            film.Add(name);
            film.Add(genre);
            film.Add(rating);
            film.Add(DateTime.Now.ToString());
            users[users.Count + 1].Films.Add(film);
            FIleEditor.SaveData(users);
        }

        public List<string> UsersWhoWatchedSameMovies(string nickname)
        {
            User user = SearchUser(nickname);
            List<string> userWhoWatched = new List<string>();
            for (var i = 0; i < users.Count; i++)
            {
                if (user.Films[0] == users[i].Films[0])
                {
                    userWhoWatched.Add(users[i].Name);
                }
            }
            return userWhoWatched;
        }

        private User SearchUser(string nickname)
        {
            for (var i = 0; i < users.Count; i++)
            {
                if (users[i].Nickname == nickname)
                {
                    return users[i];
                }
            }
            return null;
        }

        public double AverageRating(string nickname)
        {
            User user = SearchUser(nickname);
            double sum = 0;
            int count = 0;
            for (var i = 0; i < user.Films.Count; i++)
            {
                sum += Convert.ToDouble(user.Films[2]);
                count++;
            }
            if (count == 0) return -1;
            return sum / count;
        }

        public double AverageRatingByGenre(string nickname, string genre)
        {
            User user = SearchUser(nickname);
            double sum = 0;
            int count = 0;
            for (var i = 0; i < user.Films.Count; i++)
            {
                if (user.Films[1].ToString() == genre)
                {
                    sum += Convert.ToDouble(user.Films[2]);
                    count++;
                }
            }
            if (count == 0) return -1;
            return sum / count;
        }

        public List<string> ListFilmsInPeriodOfTime(string nickname, DateTime start, DateTime end)
        {
            User user = SearchUser(nickname);
            List<string> FilmsNames = new List<string>();
            for (int i = 0; i < user.Films.Count; i++)
            {
                DateTime TimeOfWatchedFilm = Convert.ToDateTime(user.Films[3]);
                if (TimeOfWatchedFilm >= start && TimeOfWatchedFilm <= end)
                {
                    FilmsNames.Add(user.Films[0].ToString());
                }
            }
            return FilmsNames;
        }
    }
}
