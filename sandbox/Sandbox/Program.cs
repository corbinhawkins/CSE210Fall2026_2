// using System;
// using System.Formats.Asn1;
// using System.Security.Cryptography.X509Certificates;

// class Program
// {
//     static double AddNumbers(double x, int y)
//         {
//             return x+y;
//         }
 
    
//     static void DisplayGreeting(string name)
// {
//     Console.WriteLine($"Welcome {name}, pleased to meet you. ");
// }
    
//     static void Main(string[] args);
//     {
   
//    double answer = AddNumbers(12.234, 10);
//    Console.WriteLine(answer);
   
   
//     }



   
//     //     X=9;
//     //     if (X==10)
//     //         Console.WriteLine("X is 10");
//     //         Console.WriteLine("Y is fun"); 

//     // }

// //trying out comments
// // bool done = false;
// // while (!done)
// //     {
// //         Console.Write("Are we done (y/n): ");
// //         done = Console.ReadLine() == "Y";
// //    bool done;
// //    do{
// //     Console.Write("Are we done (y/n): ");
// //     done = Console.ReadLine().ToLower() == "y";
      
// //     }while(!done);
//     // for(int i = 1; i < 1000; i+=1)
//     //     {
//     //         Console.WriteLine(i);
//     //     }
    
//     // List<string>myFriends = new List<string> {"BoB", "Betty", "Bubba"};
//     // List<string> names = new List<string>();
//     // myFriends.Add("James");
//     // myFriends.Add("Doug");
//     // foreach(string name in myFriends)
//     //     {
//     //         Console.WriteLine(name);
//     //     }
    
//The second quiz
class Program
{
    public static double findsmallest(List < double > runData)
    {
        double smallest = runData[0];
        foreach(double num in runData)
        {
            if (num < smallest)
            {
                smallest = num;
            }
        } 
        return smallest;
    }
    public static void Main() //ask user for height
    {
        List < double > runData = new List<double>
        {
            9.1,9.5,10.0,9.0

        };
        double smallest = findsmallest(runData);
        Console.WriteLine(smallest);
        Console.Write("Please enter your height: ");
        string response = Console.ReadLine();
        int height = int.Parse(response);

        if (height < 45)
        {
            Console.WriteLine("You are too short. ");
        }
        else if (height > 72)
        {
            Console.WriteLine("You are too tall. ");
        }
        else
        {
            Console.WriteLine("You can ride.");
        }
    }
}


