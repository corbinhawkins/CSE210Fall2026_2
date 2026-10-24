class Scripture
{
    List<Word> _words;

    //TODO: add scrripture reference

    public Scripture(string bookName, int chapter, int verse, string text)
    {
        //TODO
    }
    public Scripture(string bookName, int chapter, int startVerse)
    {
        //TODO
    }
    private List<Word> ConvertToWords(string text)
    {
        List<Word> tempWords = new List<Word>();

        string[] words = text.Split(' ');
        foreach(string word in text.Split(' '))
        {
            Word tempWord = new Word(word);
            tempWords.Add(tempWord);
        }
        return tempWords;
    }

}