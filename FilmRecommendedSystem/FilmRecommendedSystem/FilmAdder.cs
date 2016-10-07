using System;
using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class FilmAdder : IFilmAdder
    {
        List<User> users = new List<User>();
        public string Nickname { get; private set; }
        public string FilmTitle { get; private set; }
        public string Genre { get; private set; }
        public string Rating { get; private set; }

        public FilmAdder(string nickname, string filmTitle, string genre, double rating)
        {
            users = FIleEditor.LoadData();
            Nickname = nickname;
            FilmTitle = filmTitle;
            Genre = genre;
            Rating = rating.ToString();
        }

        public FilmAdder(List<User> users, string nickname, string filmTitle, string genre, double rating)
        {
            this.users = users;
            Nickname = nickname;
            FilmTitle = filmTitle;
            Genre = genre;
            Rating = rating.ToString();
        }

        public List<User> AddFilm()
        {
            List<string> film = new List<string>();
            film.Add(FilmTitle);
            film.Add(Genre);
            film.Add(Rating);
            film.Add(DateTime.Now.ToString());
            for (var i = 0; i < users.Count; i++)
            {
                if (users[i].Nickname == Nickname) users[i].Films.Add(film);
            }
            return users;
        }
    }
}
