using System;
class Entry
{
    public DateTime _date = DateTime.Today;
    public string _promptText = "";
    public string _entryText = "";

    public void Display()
    {
        Console.WriteLine(
            $"Date: {_date:yyyy-MM-dd} - Prompt: {_promptText}");

        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    public int GetWordCount()
    {
        return _entryText.Split(
            (char[]?)null,
            StringSplitOptions.RemoveEmptyEntries
        ).Length;
    }
}
