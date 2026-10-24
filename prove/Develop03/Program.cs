using System;

class Program
{
    static void Main(string[] args)
    {
        Word myWord = new Word("bubba");
        myWord.Display();
        myWord.Hide();
        myWord.WriteLine();
        myWord.Display();
    }
}