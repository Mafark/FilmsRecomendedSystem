using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public class Register : IRegister
    {
        List<User> users = new List<User>();
        public string Nickname { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Register(string nickname, string email, string name, string surname)
        {
            users = FIleEditor.LoadData();
            Nickname = nickname;
            Email = email;
            Name = name;
            Surname = surname;
        }

        public Register(List<User> users, string nickname, string email, string name, string surname)
        {
            this.users = users;
            Nickname = nickname;
            Email = email;
            Name = name;
            Surname = surname;
        }

        public List<User> Registration()
        {
            bool AlreadyRegistered = false;
            for (var i = 0; i < users.Count; i++)
            {
                if (users[i].Nickname == Nickname) AlreadyRegistered = true;
            }
            if (AlreadyRegistered == false)
            {
                users.Add(new User(Nickname, Email, Name, Surname));
            }
            return users;
        }
    }
}
