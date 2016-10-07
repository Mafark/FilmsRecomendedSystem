using System;
using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class AverageRatingByGenre : IAverageRatingByGenre
    {
        List<User> users = new List<User>();
        public string Nickname { get; private set; }
        public string Genre { get; private set; }

        public AverageRatingByGenre(string nickname, string genre)
        {
            users = FIleEditor.LoadData();
            Nickname = nickname;
            Genre = genre;
        }
        public AverageRatingByGenre(List<User> users, string nickname, string genre)
        {
            this.users = users;
            Nickname = nickname;
            Genre = genre;
        }

        public double GetAverageRatingByGenre()
        {
            User user = Searcher.SearchUser(Nickname, users);
            double sum = 0;
            int count = 0;
            for (var i = 0; i < user.Films.Count; i++)
            {
                if (user.Films[i][1] == Genre)
                {
                    sum += Convert.ToDouble(user.Films[i][2]);
                    count++;
                }
            }
            if (count == 0) return -1;
            return sum / count;
        }
    }
}
