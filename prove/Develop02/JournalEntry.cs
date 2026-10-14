class JournalEntry
{
    public DateTime _date;
    public string _prompt;
    public string _response;

    public void DisplayEntry()
    {
        Console.Write($"{_date},");
        Console.WriteLine($"{_prompt},");
        Console.WriteLine($"{_response},");

    }

public void CreateJournalEntry()
    {
       _date = DateTime.Now;
        _prompt = "How was your day? ";

        Console.Write($"{_prompt}");
        _response = Console.ReadLine();


    }


}