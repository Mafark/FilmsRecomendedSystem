using System.Collections.Generic;

namespace TrainerEnglish.Users
{
    public class UserProfile : IUserProfile
    {
        private List<Word> _words;

        public UserProfile(
            int id,
            string nickname,
            Word[] words)
        {
            Id = id;
            Nickname = nickname;
            _words = new List<Word>(words ?? new Word[0]);
        }

        public int Id { get; private set; }

        public string Nickname { get; private set; }

        public Word[] words
        {
            get
            {
                return _words.ToArray();
            }
        }

        public void AddWord(Word word)
        {
            bool found = false;
            for (var i = 0; i < _words.Count; i++)
            {
                if (_words[i].word == word.word)
                {
                    if (_words[i].Count < 3)
                    {
                        _words[i].Count++;
                        found = true;
                    }
                    else _words[i].show = false;
                }
            }
            if (!found)
            {
                _words.Add(word);
            }
        }
    }
}
