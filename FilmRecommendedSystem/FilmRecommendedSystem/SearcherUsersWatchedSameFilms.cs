using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class SearcherUsersWatchedSameFilms : ISearcherUsersWatchedSameFilms
    {
        List<User> users = new List<User>();
        public string Nickname { get; private set; }

        public SearcherUsersWatchedSameFilms(string nickname)
        {
            users = FIleEditor.LoadData();
            Nickname = nickname;
        }
        public SearcherUsersWatchedSameFilms(List<User> users, string nickname)
        {
            this.users = users;
            Nickname = nickname;
        }

        public List<string> SearchUsersWatchedSameFilms()
        {
            User user = Searcher.SearchUser(Nickname, users);
            List<string> userWhoWatched = new List<string>();
            for (var i = 0; i < users.Count; i++)
            {
                for (var j = 0; j < user.Films.Count; j++)
                {
                    for (var k = 0; k < users[i].Films.Count; k++)
                    {
                        if (user.Films[j][0] == users[i].Films[k][0] && user.Name != users[i].Name)
                        {
                            userWhoWatched.Add(users[i].Name);
                        }
                    }
                }
            }
            return userWhoWatched;
        }
    }
}
