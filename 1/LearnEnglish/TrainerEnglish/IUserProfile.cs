namespace TrainerEnglish
{
    public interface IUserProfile
    {
        int Id { get; }
        string Nickname { get; }
        Word[] words { get; }
        void AddWord(Word word);
    }
}
