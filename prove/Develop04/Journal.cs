using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
class Journal
{
    private List<Entry> _entries = new List<Entry>();

    private readonly JsonSerializerOptions _fileOptions = new JsonSerializerOptions
    {
        IncludeFields = true,
        WriteIndented = true
    };

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_entries, _fileOptions);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        string json = File.ReadAllText(filename);

        List<Entry>? loadedEntries =
            JsonSerializer.Deserialize<List<Entry>>(json, _fileOptions);

        if (loadedEntries == null || loadedEntries.Exists(entry =>
            entry == null ||
            entry._promptText == null ||
            entry._entryText == null))
        {
            throw new JsonException("The file contains invalid entries.");
        }

        _entries = loadedEntries;
    }

    public void DisplayStatistics()
    {
        int totalWords = 0;
        DateTime firstDate = DateTime.Today;

        foreach (Entry entry in _entries)
        {
            totalWords += entry.GetWordCount();

            if (entry._date.Date < firstDate)
            {
                firstDate = entry._date.Date;
            }
        }

        int totalDays = (DateTime.Today - firstDate).Days + 1;
        double average = (double)_entries.Count / totalDays;

        Console.WriteLine($"Total entries: {_entries.Count}");
        Console.WriteLine($"Total words: {totalWords}");
        Console.WriteLine($"Average entries per day: {average:F2}");
        Console.WriteLine(
            "(From the first entry through today, including days without entries.)");
    }
}