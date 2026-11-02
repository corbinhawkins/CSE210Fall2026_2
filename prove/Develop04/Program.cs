using System;
using System.IO;
using System.Text.Json;
class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to your journal!");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Write an entry");
            Console.WriteLine("2. Display entries");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal (replaces current entries)");
            Console.WriteLine("5. Show statistics");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "6" || choice == null)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            try
            {
                switch (choice)
                {
                    case "1":
                        string prompt = promptGenerator.GetRandomPrompt();

                        Console.WriteLine(prompt);
                        Console.Write("> ");

                        string response = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(response))
                        {
                            Console.WriteLine("The entry was empty and was not added.");
                            break;
                        }

                        Entry entry = new Entry
                        {
                            _date = DateTime.Today,
                            _promptText = prompt,
                            _entryText = response
                        };

                        journal.AddEntry(entry);

                        Console.WriteLine(
                            "Entry added. Choose Save journal to keep it in a file.");
                        break;

                    case "2":
                        journal.DisplayAll();
                        break;

                    case "3":
                        Console.Write(
                            "Filename to save (for example, journal.json): ");

                        string saveFilename = Console.ReadLine() ?? "";

                        journal.SaveToFile(saveFilename);
                        Console.WriteLine("Journal saved.");
                        break;

                    case "4":
                        Console.Write("Filename to load: ");

                        string loadFilename = Console.ReadLine() ?? "";

                        journal.LoadFromFile(loadFilename);
                        Console.WriteLine("Journal loaded.");
                        break;

                    case "5":
                        journal.DisplayStatistics();
                        break;

                    default:
                        Console.WriteLine("Please choose a number from 1 to 6.");
                        break;
                }
            }
            catch (IOException)
            {
                Console.WriteLine(
                    "The file could not be read or written. Check the filename and folder.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(
                    "You do not have permission to access that file.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Please enter a valid filename.");
            }
            catch (JsonException)
            {
                Console.WriteLine(
                    "That file is not a valid journal. Current entries were kept.");
            }
        }
    }
}