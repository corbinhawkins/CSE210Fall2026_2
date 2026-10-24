using System;
using System.Dynamic; //provides some c# features

public class Entry // defines a class that represents 
//a journal entry
{
    public string Date {get; set; } // stores the date when the entry was created

    public string PromptText { get; set; } //store the prompt shown to the user

    public string Response { get; set; } // stores the user's journal response

    public int WordCount //counts word response
    {
        get //defines what happens when word count is requested

        {
            string [] words = Response.Split( //splits response into seperate words
                new[] { ' ', '\t', '\r', '\n' }, // identifies spaces and line breaks as separators. 
                StringSplitOptions.RemoveEmptyEntries); // removes empty items caused by repeated spaces
        return words.Length; //returns # of words in response
        }
    
    }

public Entry(string date, string promptText,string repsonse) //creates a new entry object
    {
        Date = date; //assign the date parameter to the date property
        PromptText = promptText; 
        Response = Response;
    }

 public void Display() //display this hournal entry on the screen
    {
        Console.WriteLine($"Date: {Date}"); //display the date
        Console.WriteLine($"Prompt: {PromptText}"); //display the prompt
        Console.WriteLine($"Response: {Response}"); // display the response from user
        Console.WriteLine($"Word Count: {WordCount}"); // display the number of words in the response
        Console.WriteLine(new string('-', 50)); //this is a devider between entries

    }
public string ToFileString() //converts the entry into one line for saving
    {
        string safeDate = Date.Replace("|", "/");//repaces separator
        string safePrompt = PromptText.Replace("|",",");//same as last
        string safeResponse = Response.Replace("|",",");//same

        return $"{safeDate}|{safePrompt}|{safeResponse}";//combines all entry data using |
    }

public static Entry FromFileString(string line) // creates an entry object
    {
        string[] parts = line.Split('|', 3); //splits line into date and response
        if (parts.Length !=3) //checks if the saved line has all required parts
        {
            throw new FormatException("The journal file contains an invalid entry."); //reports invalid formatting

        }
   
return new Entry(parts[0], parts[1], parts[2]); //creates and returns an entry using the saved values


   
   
    }




}

