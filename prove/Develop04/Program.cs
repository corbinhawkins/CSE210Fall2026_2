using System; // Provides access to Console and other basic C# features.

public class Program // Defines the main Program class.
{ // Opens the Program class.

    public static void Main() // Defines the starting point of the program.
    { // Opens the Main method.
        Journal journal = new Journal(); // Creates a new Journal object.

        bool keepRunning = true; // Controls whether the menu continues to repeat.

        while (keepRunning) // Repeats the menu while the user has not selected Quit.
        { // Opens the while loop.
            DisplayMenu(); // Displays the available menu options.

            Console.Write("Select an option: "); // Asks the user to choose an option.

            string choice = Console.ReadLine() ?? string.Empty; // Reads the user's menu choice.

            choice = choice.Trim(); // Removes unnecessary spaces from the choice.

            switch (choice) // Determines which action matches the user's choice.
            { // Opens the switch statement.

                case "1": // Handles the option for writing a new entry.
                    journal.WriteEntry(); // Calls the method that creates a new entry.
                    break; // Ends this switch case.

                case "2": // Handles the option for displaying the journal.
                    journal.DisplayAll(); // Displays every entry currently in the journal.
                    break; // Ends this switch case.

                case "3": // Handles the option for loading the journal.
                    LoadJournal(journal); // Calls the helper method that loads a file.
                    break; // Ends this switch case.

                case "4": // Handles the option for saving the journal.
                    SaveJournal(journal); // Calls the helper method that saves a file.
                    break; // Ends this switch case.

                case "5": // Handles the additional statistics option.
                    journal.DisplayStatistics(); // Displays journal statistics.
                    break; // Ends this switch case.

                case "6": // Handles the option for quitting the program.
                    keepRunning = false; // Stops the while loop.
                    Console.WriteLine("Thank you for using the Journal Program."); // Displays a closing message.
                    break; // Ends this switch case.

                default: // Handles any invalid menu choice.
                    Console.WriteLine("That option is not valid. Please try again."); // Explains that the choice was invalid.
                    break; // Ends the default case.
            } // Closes the switch statement.

            Console.WriteLine(); // Adds a blank line before the menu appears again.
        } // Closes the while loop.
    } // Closes the Main method.

    private static void DisplayMenu() // Displays the program menu.
    { // Opens the DisplayMenu method.
        Console.WriteLine("Journal Menu"); // Displays the menu title.
        Console.WriteLine("1. Write a new entry"); // Displays the write option.
        Console.WriteLine("2. Display the journal"); // Displays the display option.
        Console.WriteLine("3. Load the journal from a file"); // Displays the load option.
        Console.WriteLine("4. Save the journal to a file"); // Displays the save option.
        Console.WriteLine("5. Display journal statistics"); // Displays the additional statistics option.
        Console.WriteLine("6. Quit"); // Displays the quit option.
    } // Closes the DisplayMenu method.

    private static void SaveJournal(Journal journal) // Saves the journal after asking for a filename.
    { // Opens the SaveJournal method.
        Console.Write("Enter the filename to save to: "); // Asks the user for a filename.

        string filename = Console.ReadLine() ?? string.Empty; // Reads the filename.

        if (string.IsNullOrWhiteSpace(filename)) // Checks whether the filename is empty.
        { // Opens the if statement.
            Console.WriteLine("A filename is required."); // Explains why the save cannot continue.
            return; // Leaves the method without saving.
        } // Closes the if statement.

        try // Begins code that might produce a file error.
        { // Opens the try block.
            journal.SaveToFile(filename); // Saves the journal to the selected file.
        } // Closes the try block.
        catch (UnauthorizedAccessException exception) // Handles permission errors.
        { // Opens the catch block.
            Console.WriteLine($"The file could not be saved: {exception.Message}"); // Displays the permission error.
        } // Closes the catch block.
        catch (IOException exception) // Handles other file-writing errors.
        { // Opens the catch block.
            Console.WriteLine($"The file could not be saved: {exception.Message}"); // Displays the file error.
        } // Closes the catch block.
    } // Closes the SaveJournal method.

    private static void LoadJournal(Journal journal) // Loads the journal after asking for a filename.
    { // Opens the LoadJournal method.
        Console.Write("Enter the filename to load: "); // Asks the user for a filename.

        string filename = Console.ReadLine() ?? string.Empty; // Reads the filename.

        if (string.IsNullOrWhiteSpace(filename)) // Checks whether the filename is empty.
        { // Opens the if statement.
            Console.WriteLine("A filename is required."); // Explains why loading cannot continue.
            return; // Leaves the method without loading.
        } // Closes the if statement.

        try // Begins code that might produce a file error.
        { // Opens the try block.
            journal.LoadFromFile(filename); // Loads entries from the selected file.
        } // Closes the try block.
        catch (FileNotFoundException exception) // Handles the case where the file does not exist.
        { // Opens the catch block.
            Console.WriteLine($"The file could not be found: {exception.Message}"); // Displays the missing-file error.
        } // Closes the catch block.
        catch (FormatException exception) // Handles incorrectly formatted journal files.
        { // Opens the catch block.
            Console.WriteLine($"The file format is invalid: {exception.Message}"); // Displays the format error.
        } // Closes the catch block.
        catch (IOException exception) // Handles other file-reading errors.
        { // Opens the catch block.
            Console.WriteLine($"The file could not be loaded: {exception.Message}"); // Displays the file error.
        } // Closes the catch block.
    } // Closes the LoadJournal method.
} // Closes the Program class.