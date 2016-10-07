using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class Searcher
    {
        public static User SearchUser(string nickname, List<User> users)
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
    }
}
