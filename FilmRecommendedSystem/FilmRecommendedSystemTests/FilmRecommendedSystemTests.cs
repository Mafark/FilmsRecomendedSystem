using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmRecommendedSystem;
using System.Collections.Generic;
using System.Linq;

namespace FilmRecommendedSystemTests
{
    [TestClass]
    public class FilmRecommendedSystemTests
    {
        [TestMethod]
        public void UserRegistrationWithEmptyList_EqualNewListOfUsers()
        {
            List<User> users = new List<User>();
            List<User> expectedUsers = new List<User>();
            expectedUsers.Add(new User("1", "2", "3", "4"));
            var newUsers = new Register(users, "1", "2", "3", "4");
            bool AreEqual = true;

            users = newUsers.Registration();
            if (users.Count != expectedUsers.Count) AreEqual = false;
            if (users[0].Nickname != expectedUsers[0].Nickname ||
                users[0].Email != expectedUsers[0].Email ||
                users[0].Name != expectedUsers[0].Name ||
                users[0].Surname != expectedUsers[0].Surname) AreEqual = false;

            Assert.IsTrue(AreEqual);
        }

        [TestMethod]
        public void UserRegistrationWithNotEmptyList_EqualNewListOfUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User("0", "0", "0", "0"));
            List<User> expectedUsers = new List<User>();
            expectedUsers.Add(new User("0", "0", "0", "0"));
            expectedUsers.Add(new User("1", "2", "3", "4"));
            var newUsers = new Register(users, "1", "2", "3", "4");
            bool AreEqual = true;

            users = newUsers.Registration();
            if (users.Count != expectedUsers.Count) AreEqual = false;
            if (users[1].Nickname != expectedUsers[1].Nickname ||
                users[1].Email != expectedUsers[1].Email ||
                users[1].Name != expectedUsers[1].Name ||
                users[1].Surname != expectedUsers[1].Surname) AreEqual = false;

            Assert.IsTrue(AreEqual);
        }

        [TestMethod]
        public void AddFilmIfUserFound_EqualityOfTwoLists()
        {
            List<User> users = new List<User>();
            users.Add(new User("0", "0", "0", "0"));
            List<User> expectedUsers = new List<User>();
            expectedUsers.Add(new User("0", "0", "0", "0"));
            List<string> film = new List<string>();
            film.Add("filmTitle");
            film.Add("genre");
            film.Add("9,8");
            film.Add(DateTime.Now.ToString());
            expectedUsers[0].Films.Add(film);
            var newFilmInUser = new FilmAdder(users, "0", "filmTitle", "genre", 9.8);
            bool AreEqual = true;

            users = newFilmInUser.AddFilm();
            if (users.Count != expectedUsers.Count) AreEqual = false;
            if (users[0].Films[0][0] != expectedUsers[0].Films[0][0] ||
                users[0].Films[0][1] != expectedUsers[0].Films[0][1] ||
                users[0].Films[0][2] != expectedUsers[0].Films[0][2]) AreEqual = false;

            Assert.IsTrue(AreEqual);
        }

        [TestMethod]
        public void AddFilmIfUserNotFound_EqualityOfTwoLists()
        {
            List<User> users = new List<User>();
            users.Add(new User("1", "0", "0", "0"));
            List<User> expectedUsers = new List<User>();
            expectedUsers.Add(new User("0", "0", "0", "0"));
            var newFilmInUser = new FilmAdder(users, "0", "filmTitle", "genre", 9.8);

            users = newFilmInUser.AddFilm();

            Assert.AreEqual(expectedUsers[0].Films.Count, users[0].Films.Count);
        }

        [TestMethod]
        public void SearchUsersWatchedSameFilms_TrueNickname()
        {
            List<User> users = new List<User>();
            users.Add(new User("0", "0", "0", "0"));
            users.Add(new User("1", "0", "0", "0"));
            users.Add(new User("2", "2", "2", "2"));
            List<string> film = new List<string>();
            film.Add("filmTitle");
            film.Add("genre");
            film.Add("9,8");
            film.Add(DateTime.Now.ToString());
            users[0].Films.Add(film);
            users[2].Films.Add(film);
            var search = new SearcherUsersWatchedSameFilms(users, users[0].Name);
            List<string> usersWhoWatched = new List<string>();

            usersWhoWatched = search.SearchUsersWatchedSameFilms();

            Assert.AreEqual("2", usersWhoWatched[0]);
        }

        [TestMethod]
        public void GetAverageRating_EqualityRatings()
        {
            List<User> users = new List<User>();
            double expectedCount = 3;
            users.Add(new User("0", "0", "0", "0"));
            List<string> film1 = new List<string>();
            film1.Add("filmTitle");
            film1.Add("genre");
            film1.Add("5");
            film1.Add(DateTime.Now.ToString());
            users[0].Films.Add(film1);
            List<string> film2 = new List<string>();
            film2.Add("filmTitle");
            film2.Add("genre");
            film2.Add("1");
            film2.Add(DateTime.Now.ToString());
            users[0].Films.Add(film2);
            var averageRating = new AverageRating(users, "0");

            double count = averageRating.GetAverageRating();

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void GetAverageRatingByGenre_EqualityRatings()
        {
            List<User> users = new List<User>();
            double expectedCount = 3;
            users.Add(new User("0", "0", "0", "0"));
            List<string> film1 = new List<string>();
            film1.Add("filmTitle");
            film1.Add("genre");
            film1.Add("5");
            film1.Add(DateTime.Now.ToString());
            users[0].Films.Add(film1);
            List<string> film2 = new List<string>();
            film2.Add("filmTitle");
            film2.Add("genre");
            film2.Add("1");
            film2.Add(DateTime.Now.ToString());
            users[0].Films.Add(film2);
            var averageRatingByGenre = new AverageRatingByGenre(users, "0", "genre");

            double count = averageRatingByGenre.GetAverageRatingByGenre();

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void GetListFilmsForPeriodOfTime_EqualityOfTwoLists()
        {
            List<User> users = new List<User>();
            List<string> expectedListFilms = new List<string>();
            expectedListFilms.Add("filmTitle");
            expectedListFilms.Add("filmTitleTwo");
            users.Add(new User("0", "0", "0", "0"));
            List<string> film1 = new List<string>();
            film1.Add("filmTitle");
            film1.Add("genre");
            film1.Add("5");
            film1.Add(new DateTime(2015, 7, 20).ToString());
            users[0].Films.Add(film1);
            List<string> film2 = new List<string>();
            film2.Add("filmTitleTwo");
            film2.Add("genre");
            film2.Add("1");
            film2.Add(new DateTime(2016, 1, 20).ToString());
            users[0].Films.Add(film2);

            var list = new ListFilms(users, "0", new DateTime(2014, 7, 20), DateTime.Now);
            List<string> listFilms = list.ListFilmsForPeriodOfTime();

            var firstListNotSecond = expectedListFilms.Except(listFilms).ToList();
            var secondListNotFirst = listFilms.Except(expectedListFilms).ToList();
            Assert.IsTrue(!firstListNotSecond.Any() && !secondListNotFirst.Any());
        }

        [TestMethod]
        public void SearchUserInListOfUsersByNickname_TrueNickname()
        {
            List<User> users = new List<User>();
            users.Add(new User("0", "0", "0", "0"));
            users.Add(new User("1", "0", "0", "0"));
            users.Add(new User("2", "1", "2", "3"));
            users.Add(new User("3", "0", "0", "0"));
            string nickname = "2";
            bool NickIsTrue = true;

            var user = Searcher.SearchUser(nickname, users);

            if (user.Nickname != nickname) NickIsTrue = false;
            Assert.IsTrue(NickIsTrue);
        }
    }
}
