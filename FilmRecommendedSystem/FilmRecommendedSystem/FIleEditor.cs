using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FilmRecommendedSystem
{
    class FIleEditor
    {
        public static List<User> LoadData()
        {
            List<User> users = new List<User>();
            if (!File.Exists("users.json")) File.Create("users.json");
            users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json"));
            return users;
        }

        public static void SaveData(List<User> users)
        {
            File.WriteAllText("users.json", JsonConvert.SerializeObject(users));
        }
    }
}
