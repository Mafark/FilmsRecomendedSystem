using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainerEnglish;
using TrainerEnglish.Users;
using Newtonsoft.Json;

namespace EnglishTrainerTests
{
    [TestClass]
    public class EnglishTrainerTests
    {
        [TestMethod]
        public void GetListWords_GetNotNullArrayWith4Elements()
        {
            string userProfiles = "[{\"Id\":0,\"Nickname\":\"nickname0\",\"words\":[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"transfer\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"transfer\":\"Перевод1\"}]},{\"Id\":1,\"Nickname\":\"nickname1\",\"words\":[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"transfer\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"transfer\":\"Перевод1\"}]}]";
            string wordsRepository = "[{\"show\":true,\"Count\":0,\"word\":\"Слово0\",\"transfer\":\"Перевод0\"},{\"show\":true,\"Count\":0,\"word\":\"Слово1\",\"transfer\":\"Перевод1\"},{\"show\":true,\"Count\":0,\"word\":\"Слово2\",\"transfer\":\"Перевод2\"},{\"show\":true,\"Count\":0,\"word\":\"Слово3\",\"transfer\":\"Перевод3\"},{\"show\":true,\"Count\":0,\"word\":\"Слово4\",\"transfer\":\"Перевод4\"}]";
            var users = new UserProfileRepositiryStub(userProfiles);
            var words = new WordsRepositoryStub(wordsRepository);
            var englishTrainer = new EnglishTrainer(users, words);
            bool arrayIsFilled = true;

            englishTrainer.SessionStart(0);
            string[] listWords = englishTrainer.GetListWords(4);

            for(var i = 0; i < 4; i++)
            {
                if (listWords[i] == null) arrayIsFilled = false;
            }
            Assert.IsTrue(arrayIsFilled && (listWords.Length == 4));
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

        class WordsRepositoryStub : IWordsRepository
        {
            private readonly string _jsonDatabase;

            public WordsRepositoryStub(string json)
            {
                _jsonDatabase = json;
            }

            public Word[] GetAllWords()
            {
                var words = JsonConvert.DeserializeObject<Word[]>(_jsonDatabase);
                return words;
            }
        }
    }


}
