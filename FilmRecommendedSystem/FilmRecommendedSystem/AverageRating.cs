using System;
using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class AverageRating : IAverageRating
    {
        List<User> users = new List<User>();
        public string Nickname { get; private set; }

        public AverageRating(string nickname)
        {
            users = FIleEditor.LoadData();
            Nickname = nickname;
        }
        public AverageRating(List<User> users, string nickname)
        {
            this.users = users;
            Nickname = nickname;
        }

        public double GetAverageRating()
        {
            User user = Searcher.SearchUser(Nickname, users);
            double sum = 0;
            int count = 0;
            for (var i = 0; i < user.Films.Count; i++)
            {
                sum += Convert.ToDouble(user.Films[i][2]);
                count++;
            }
            if (count == 0) return -1;
            return sum / count;
        }
    }
}
