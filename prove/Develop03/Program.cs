using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Exceeds requirements: randomly selects from a library of scriptures
        // and hides only visible words so every round makes progress.
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me.")
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Practice complete!");
                break;
            }

            Console.Write("Press Enter to hide 3 words, or type quit to finish: ");
            string input = Console.ReadLine() ?? "quit";

            if (input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (input.Trim() == "")
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}