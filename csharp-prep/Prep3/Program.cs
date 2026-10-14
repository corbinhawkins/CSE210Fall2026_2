//Console>ReadLine() gets input.
//int.Parse() converts text into a number.
//if statements make decisions.
//while loops repeate while a condition is true.
//do-while loops run at least once.
//random generates the coputers number. 




using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());


while (guess != magicNumber)
{ 
        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
    }}



}