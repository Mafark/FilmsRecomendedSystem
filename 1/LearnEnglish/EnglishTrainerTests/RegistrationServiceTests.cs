using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainerEnglish;
using Newtonsoft.Json;
using TrainerEnglish.Users;
using TrainerEnglish.Application;

namespace EnglishTrainerTests
{
    [TestClass]
    public class RegistrationServiceTests
    {
        [TestMethod]
        public void RegisterUser_ReturnCorrectID()
        {
            string userProfiles = "[{\"Id\":0,\"Nickname\":\"nickname0\",\"words\":[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"transfer\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"transfer\":\"Перевод1\"}]},{\"Id\":1,\"Nickname\":\"nickname1\",\"words\":[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"transfer\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"transfer\":\"Перевод1\"}]}]";
            var users = new UserProfileRepositiryStub(userProfiles);
            var registrationService = new RegistrationService(users);
            var expectedUserId = 2;

            var newUserId = registrationService.RegisterUser("testUser");

            Assert.AreEqual(expectedUserId, newUserId);
        }
    }

    class UserProfileRepositiryStub : IUserProfileRepository
    {
        private readonly string _jsonDatabase;

        public UserProfileRepositiryStub(string json)
        {
            _jsonDatabase = json;
        }

        public IUserProfile[] GetAllUserProfiles()
        {
            var userProfiles = JsonConvert.DeserializeObject<UserProfile[]>(_jsonDatabase);
            return userProfiles;
        }

        public IUserProfile GetUserProfile(int userId)
        {
            var userProfiles = GetAllUserProfiles();
            foreach (var userProfile in userProfiles)
            {
                if (userProfile.Id == userId)
                {
                    return userProfile;
                }
            }

            return null;
        }

        public void SaveUserProfile(IUserProfile userProfile)
        {
        }
    }
}
