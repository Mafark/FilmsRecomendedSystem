using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FilmRecommendedSystem
{
    public class FIleEditor
    {
        public static List<User> LoadData()
        {
            List<User> users = new List<User>();
            if (!File.Exists("users.json")) File.Create("users.json");
            users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json"));
            if (users != null)
                return users;
            else return new List<User>();
        }

        public static void SaveData(List<User> users)
        {
            File.WriteAllText("users.json", JsonConvert.SerializeObject(users));
        }
    }
}
