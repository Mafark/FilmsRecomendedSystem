using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmRecommendedSystem;
namespace FilmRecommendedSystemTests
{
    [TestClass]
    public class FilmRecommendedSystemTests
    {
        [TestMethod]
        public void TestProgramm()
        {
            var s = new RecommendedFilmSystem();
            s.Register("Nick", "Email", "Name", "Surname");
        }
    }
}
