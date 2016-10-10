using System;

namespace TrainerEnglish
{
    public class EnglishTrainer : IEnglishTrainer
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private Word[] _wordsRepository;
        private IUserProfile _userProfile;
        private string correctAnswer;
        private Word correctWord;
        static Random rand = new Random();


        public EnglishTrainer(IUserProfileRepository userProfileRepository, IWordsRepository wordsRepository)
        {
            _userProfileRepository = userProfileRepository;
            _wordsRepository = wordsRepository.GetAllWords();
        }

        public void SessionStart(int UserId)
        {
            _userProfile = _userProfileRepository.GetUserProfile(UserId);
        }

        public string[] GetListWords(int length)
        {
            string[] words = new string[length];
            int index = rand.Next(0, words.Length);
            while(!_wordsRepository[index].show)
            {
                index = rand.Next(0, words.Length);
            }
            correctWord = _wordsRepository[index];
            words[0] = correctWord.word;
            var numberOfCorrectTransfer = rand.Next(1, length);
            correctAnswer = correctWord.transfer;
            words[numberOfCorrectTransfer] = correctAnswer;
            int notCorrectWord = rand.Next(0, words.Length);
            for (var i = 1; i < length; i++)
            {
                if (i != numberOfCorrectTransfer)
                {
                    notCorrectWord = rand.Next(0, words.Length);
                    while (notCorrectWord == index)
                    {
                        notCorrectWord = rand.Next(0, words.Length);
                    }
                    words[i] = _wordsRepository[notCorrectWord].transfer;
                }
                else
                {
                    continue;
                }
            }
            return words;
        }

        public bool SaveReulst(string selectedWord)
        {
            if (correctAnswer == selectedWord)
            {
                _userProfile.AddWord(correctWord);
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GetRandomTransferWord()
        {
            var index = rand.Next(0, _wordsRepository.Length);
            return _wordsRepository[index].transfer;
        }
    }
}
