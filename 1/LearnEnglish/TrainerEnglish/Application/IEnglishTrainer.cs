namespace TrainerEnglish
{
    public interface IEnglishTrainer
    {
        void SessionStart(int UserId);
        string[] GetListWords(int length); // First ellement of array - the original word.
        bool SaveReulst(string selectedWord);
    }
}
