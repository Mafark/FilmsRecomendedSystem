using System.Collections.Generic;

namespace FilmRecommendedSystem
{
    public interface IRegister
    {
        string Nickname { get; }
        string Email { get; }
        string Name { get; }
        string Surname { get; }
        List<User> Registration();
    }
}
