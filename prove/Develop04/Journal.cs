using System; //provides console, datetime, and other features
using System.Collections.Generic; // provides the list of collection
using System.IO; // provides file reading and writing tool

public class Journal //defines a class to manage journal entries
{
    private List<Entry> _entries;//stores all entries correctly in the journal
    private List<string> _prompts;// stores the prompts that can be randomly selected
    private Random _random;// generates random prompt numbers
    public Journal() // create a new empty journal object
    {
        _entries = new List<Entry>(); // creates an empty list for journal entries
        _prompts = new List<string> //list of journal prompts
        {
            "Who was the most interesting person I intereacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I ad one thing I could do over today, what would it be?",
            "What is one goal I want to accomplish tomorrow?",
            "What is something I learned today?",
            "What is one thing I am greatful for today?",
        };
    _random = new Random(); //creates random # generaotr
    }
public void WriteEntry()
    {
        int promptIndex = _random.Next(_prompts.Count); 
        string prompt = _prompts[promptIndex];
        Console.WriteLine();
        Console.WriteLine($"Prompt: {prompt}"); // Shows the prompt to the user.
        Console.Write("Response: "); // Asks the user to enter a response.

        string response = Console.ReadLine() ?? string.Empty; // Reads the user's response.

        string date = DateTime.Now.ToString("MM/dd/yyyy"); // Gets today's date as text.

        Entry newEntry = new Entry(date, prompt, response); // Creates a new Entry object.

        _entries.Add(newEntry); // Adds the new entry to the journal list.

        Console.WriteLine("Your entry was added successfully."); // Confirms that the entry was saved in memory.
    } // Closes the WriteEntry method.

    public void DisplayAll() // Displays every entry in the journal.
    { // Opens the DisplayAll method.
        if (_entries.Count == 0) // Checks whether the journal has no entries.
        { // Opens the if statement.
            Console.WriteLine("There are no journal entries to display."); // Informs the user that the journal is empty.
            return; // Stops the method because there are no entries to display.
        } // Closes the if statement.

        foreach (Entry entry in _entries) // Loops through every Entry object.
        { // Opens the foreach loop.
            entry.Display(); // Displays the current entry.
        } // Closes the foreach loop.
    } // Closes the DisplayAll method.

    public void SaveToFile(string filename) // Saves all entries to a file.
    { // Opens the SaveToFile method.
        using (StreamWriter writer = new StreamWriter(filename)) // Opens the requested file for writing.
        { // Opens the using block.
            foreach (Entry entry in _entries) // Loops through every journal entry.
            { // Opens the foreach loop.
                writer.WriteLine(entry.ToFileString()); // Writes one formatted entry to the file.
            } // Closes the foreach loop.
        } // Closes the using block and automatically closes the file.

        Console.WriteLine("The journal was saved successfully."); // Confirms that the save completed.
    } // Closes the SaveToFile method.

    public void LoadFromFile(string filename) // Loads journal entries from a file.
    { // Opens the LoadFromFile method.
        List<Entry> loadedEntries = new List<Entry>(); // Creates a temporary list for loaded entries.

        string[] lines = File.ReadAllLines(filename); // Reads every line from the selected file.

        foreach (string line in lines) // Loops through every line in the file.
        { // Opens the foreach loop.
            if (!string.IsNullOrWhiteSpace(line)) // Ignores blank lines in the file.
            { // Opens the if statement.
                Entry entry = Entry.FromFileString(line); // Converts the line into an Entry object.

                loadedEntries.Add(entry); // Adds the converted entry to the temporary list.
            } // Closes the if statement.
        } // Closes the foreach loop.

        _entries = loadedEntries; // Replaces the current journal with the loaded entries.

        Console.WriteLine("The journal was loaded successfully."); // Confirms that loading completed.
    } // Closes the LoadFromFile method.

    public void DisplayStatistics() // Displays additional information about the journal.
    { // Opens the DisplayStatistics method.
        int totalWords = 0; // Creates a variable to hold the total number of words.

        foreach (Entry entry in _entries) // Loops through every journal entry.
        { // Opens the foreach loop.
            totalWords += entry.WordCount; // Adds the current entry's word count to the total.
        } // Closes the foreach loop.

        double averageWords = 0; // Creates a variable for the average number of words.

        if (_entries.Count > 0) // Checks whether the journal contains entries.
        { // Opens the if statement.
            averageWords = (double)totalWords / _entries.Count; // Calculates the average words per entry.
        } // Closes the if statement.

        Console.WriteLine($"Number of entries: {_entries.Count}"); // Displays the number of entries.
        Console.WriteLine($"Total words written: {totalWords}"); // Displays the total number of words.
        Console.WriteLine($"Average words per entry: {averageWords:F1}"); // Displays the average with one decimal place.
    } 
} 
    




