using System;

class Program
{
    static void Main(string[] args)
    {
        Menu myMenu = new Menu();
      
        int response = 0;
        while (response != 5)
        {  response = myMenu.ProcessMenu();
            switch(response)
            {
                case 1:
                    Console.WriteLine("Create");
                    break;
                case 2:
                    Console.WriteLine("Display");
                    break;
                case 3:
                    Console.WriteLine("Save");
                    break;
                case 4: 
                    Console.WriteLine("Write");   
                    break; 
            }
        }


        
    }
}