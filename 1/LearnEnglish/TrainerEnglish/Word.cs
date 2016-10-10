namespace TrainerEnglish
{
    public class Word
    {
        public Word(string word, string transfer)
        {
            this.word = word;
            this.transfer = transfer;
            Count = 0;
            show = true;
        }
        public bool show { get; set; }
        public int Count { get; set; }
        public string word { get; private set; }
        public string transfer { get; private set; }
    }
}
