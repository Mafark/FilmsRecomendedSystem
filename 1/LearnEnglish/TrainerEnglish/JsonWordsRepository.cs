using Newtonsoft.Json;
using System.IO;

namespace TrainerEnglish
{
    public class JsonWordsRepository : IWordsRepository
    {
        private readonly string _databaseFilePath;

        public JsonWordsRepository(string databaseFilePath)
        {
            _databaseFilePath = databaseFilePath;
        }

        public Word[] GetAllWords()
        {
            var serializedUsers = File.ReadAllText(_databaseFilePath);
            var words = JsonConvert.DeserializeObject<Word[]>(serializedUsers);
            return words;
        }
    }
}
