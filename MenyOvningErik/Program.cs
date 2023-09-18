
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Threading.Channels;
using System.Xml.Schema;

namespace Meny
 {


    class Program{
    
    static void Main(string[] args)
        {

            bool close = false; //Bool check to keep the program runnning untill told otherwise.

            while (close == false) {

                Console.WriteLine("Welcome to the main menu. Please type 0 to exit the app. Type 1 to check the price for various agegroup, 2 for price callibrations. Type 3 for repeating lines or 4 to find the magical (third) word.");
                
                int choice = int.TryParse(Console.ReadLine(), out choice) ? choice : 5; // Checks the userinput and tries to parse it for int.
                                                                                        // if it fails and returns default/null, it choices 5 automatically, which asks you to try again.

                int priceYoung = 80;
                int priceOld = 90;
                int priceNormal = 120;

                switch (choice)
                {

                    default:
                        Console.WriteLine("that is not a number specified for menu options. Shame on you.");
                        Console.ReadLine();
                        break;


                    case 0:
                        //Closes the app
                        Console.WriteLine("Goodbye");
                        Console.ReadLine();
                        close = true;

                        break;

                    case 1:
                        //splits up the user input sentance.
                        Console.WriteLine("Write the age of the person");

                        int age = int.Parse(Console.ReadLine());

                        //if nesting to find what pricing is relavant.


                        if (age >= 20 && age <= 60)
                        {


                            Console.WriteLine("Standardpris: 120kr");
                            Console.ReadLine();


                        }
                        else if (age < 20)
                        {

                            if (age < 5)
                            {
                                Console.WriteLine("Gratis Entré");
                                Console.ReadLine();
                            }


                            else
                            {
                                Console.WriteLine("Ungdomspris: 80kr");
                                Console.ReadLine();
                            }

                        }

                        else if (age > 64)
                        {



                            if (age >= 100) {
                                Console.WriteLine("Gratis Entré");
                                Console.ReadLine();
                            }

                            else
                            {
                                Console.WriteLine("Pensionärspris: 90kr");
                                Console.ReadLine();
                            }
                        }
                        Console.WriteLine(" ");
                        break;

                    case 2:

                        Console.WriteLine("Please enter the number of people attending");

                        int attendees;

                        if (int.TryParse(Console.ReadLine(), out attendees)) //number of people, that will be used as a check for the loop to keep going.
                        {
                            int partySize = attendees; //the total amount of people, saved seperatly as attendees is going to shrink with each each loop.
                            var attendeeList = new int[attendees]; //array to check store the age data in for checking.
                            int n = 0; // Used to trough 
                            int totalSum = 0; //Increasing sum total of each loop.


                            while (attendees > 0)
                            {

                                Console.WriteLine("Thank you. Now write the ages of each person attending.");
                                int agesListing;
                                if (int.TryParse(Console.ReadLine(), out agesListing))
                                {
                                    attendeeList[n] = agesListing; //Storing each age input. 
                                    attendees--;
                                    attendeeList[n] = agesListing;
                                }
                                else {
                                    Console.WriteLine("Write a valid age");
                                    Console.WriteLine("");
                                }


                            }

                            if (attendees == 0)
                            {



                                for (int i = 0; i < attendeeList.Length; i += 1)
                                {

                                    if (attendeeList[n] >= 20 && attendeeList[n] <= 64)
                                    {
                                        n++;
                                        totalSum += priceNormal;

                                    }

                                    else if (attendeeList[n] < 20)
                                    {
                                        n++;
                                        totalSum += priceYoung;
                                    }

                                    else if (attendeeList[n] > 64)
                                    {
                                        n++;
                                        totalSum += priceOld;
                                    }

                                }

                                Console.WriteLine("The total cost of your part of" + " " + partySize + " is " + totalSum + ".");
                            }
                        }

                        else {
                            Console.WriteLine("Write a valid number");
                        }


                        break;
                    case 3:

                        Console.WriteLine("Write a line to repeat");
                        var line = Console.ReadLine();  //Saves the sentence before it repeats it 10 times. 
                    
                        for (int i = 0; i < 10; i++) 
                        {
                            Console.Write(line + ", ");
                        }

                        break;
                    case 4:
                       
                        Console.WriteLine("Write a sentence of at least 3 words.");

                        string whole = Console.ReadLine(); 
                        string[] third = whole.Split(" "); //splits up the user input sentance.

                        int thirdLength = third.Length; // Check the length of the split up sentance to see if the arrays index exceed the minum word count or not. If they do no reach the requirement,
                                                        // it simply tells you to write a longer one before returning you to the main menu.
                        if (thirdLength <= 2) 

                        {

                            Console.WriteLine("Write a sentence of at least 3 words.");

                        }
                        else
                        { 
                        Console.Write("Your third word is: " + third[2]);
                            Console.Write(" ");
                        }
                        

                    break;
              
                }


            }

        }
    
    
    
    }

}