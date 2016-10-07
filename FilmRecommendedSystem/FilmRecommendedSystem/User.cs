using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class User
    {
        public User(string nickname, string email, string name, string surname)
        {
            Nickname = nickname;
            Email = email;
            Name = name;
            Surname = surname;
        }
        public string Nickname { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public List<List<string>> Films = new List<List<string>>();
    }
}
